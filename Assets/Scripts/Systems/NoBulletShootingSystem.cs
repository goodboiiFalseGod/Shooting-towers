using Leopotam.Ecs;
using System.Threading;
using System.Threading.Tasks;

namespace Client {
    sealed class NoBulletShootingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Shooter, Damage, Particles>.Exclude<Unplaced> _filterNoBulletTower;
        EcsFilter<ID, RecievedDamage> _filterEnemy;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterNoBulletTower)
            {
                ref Shooter shooterComponent = ref _filterNoBulletTower.Get1(index);
                ref Damage damageComponent = ref _filterNoBulletTower.Get2(index);
                ref Particles particlesComponent = ref _filterNoBulletTower.Get3(index);

                if(shooterComponent.currentCooldown <= 0)
                {
                    foreach (var index1 in _filterEnemy)
                    {
                        ref ID IDComponent = ref _filterEnemy.Get1(index1);
                        ref RecievedDamage RecievedDamageComponent = ref _filterEnemy.Get2(index1);

                        for(int i = 0; i < shooterComponent.targetsIDs.Length; i++)
                        {
                            if (IDComponent.value == shooterComponent.targetsIDs[i])
                            {
                                RecievedDamageComponent.fire = damageComponent.fire;
                                RecievedDamageComponent.lightning = damageComponent.lightning;
                                RecievedDamageComponent.physic = damageComponent.physic;
                                RecievedDamageComponent.water = damageComponent.water;

                                shooterComponent.currentCooldown = shooterComponent.cooldown;

                                _filterNoBulletTower.GetEntity(index).Get<JustShooted>();
                            }
                        }
                    }
                }
            }
        }
    }
}