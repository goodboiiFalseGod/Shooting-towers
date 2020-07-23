using Assets;
using Assets.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {

        public Configuration configuration;

        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                // register your systems here, for example:
                .Add(new CheckAreInRangeSystem())
                .Add(new FAimSystem())
                .Add(new WAimSystem())
                .Add(new TargetingSystem())
                .Add(new CooldownControlSystem())
                .Add(new BulletShootingSystem())
                .Add(new BulletMovingSystem())
                .Add(new BulletHitSystem())
                .Add(new NoBulletShootingSystem())
                .Add(new TakingDamageSystem())
                .Add(new DeathSystem())
                .Add(new EnemyFlyingSystem())
                .Add(new EnemyMovingSystem())
                .Add(new CityDamageSystem())

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                .Inject(configuration)
                .Init ();

            SingleTone.mainworld = _world;
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}