using Assets;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class BulletHitSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        private Configuration configuration;

        EcsFilter<Damage, TargetID, TransformRef, Speed> _filterBullet;
        EcsFilter<ID, TransformRef, RecievedDamage> _filterTargets;

        void IEcsRunSystem.Run()
        {
            // add your run code here.
            foreach (var index in _filterBullet)
            {
                ref Damage damageComponent = ref _filterBullet.Get1(index);
                ref TargetID targetIDComponent = ref _filterBullet.Get2(index);
                ref TransformRef transformRefComponent = ref _filterBullet.Get3(index);
                ref Speed speedComponent = ref _filterBullet.Get4(index);

                foreach (var index1 in _filterTargets)
                {
                    ref ID IDComponent = ref _filterTargets.Get1(index1);
                    ref TransformRef targetTransformRefComponent = ref _filterTargets.Get2(index1);
                    ref RecievedDamage recievedDamageComponent = ref _filterTargets.Get3(index1);

                    if (IDComponent.value == targetIDComponent.value)
                    {
                        float dis = Vector3.Distance(targetTransformRefComponent.transform.position, transformRefComponent.transform.position);

                        if(dis < 0.1f)
                        {
                            recievedDamageComponent.fire = damageComponent.fire;
                            recievedDamageComponent.lightning = damageComponent.lightning;
                            recievedDamageComponent.physic = damageComponent.physic;
                            recievedDamageComponent.water = damageComponent.water;

                            Object.Destroy(transformRefComponent.transform.gameObject);
                            _filterBullet.GetEntity(index).Destroy();
                        }
                    }
                }
            }
        }
    }
}