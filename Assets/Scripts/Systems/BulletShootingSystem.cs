using Assets.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class BulletShootingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Shooter, Damage, BulletType, TransformRef> _filterShooter;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterShooter)
            {
                ref Shooter shooterComponent = ref _filterShooter.Get1(index);
                ref Damage damageComponent = ref _filterShooter.Get2(index);
                ref BulletType bulletTypeComponent = ref _filterShooter.Get3(index);
                ref TransformRef transformRefComponent = ref _filterShooter.Get4(index);

                if(shooterComponent.currentCooldown <= 0)
                {   
                    for(int i = 0; i < shooterComponent.targetsIDs.Length; i++)
                    {   
                        if(shooterComponent.targetsIDs[i] != -1)
                        {
                            GameObject bullet = Object.Instantiate(bulletTypeComponent.bullet, transformRefComponent.transform.position, transformRefComponent.transform.rotation);
                            CreateBullet(bullet, shooterComponent.targetsIDs[i], damageComponent);
                            shooterComponent.currentCooldown = shooterComponent.cooldown;
                        }
                    }
                }
            }
        }

        void CreateBullet(GameObject bullet, int targetID, Damage damage)
        {
            EcsEntity bulletEnity = SingleTone.mainworld.NewEntity();

            bulletEnity.Get<Bullet>();

            ref Damage DamageComponent = ref bulletEnity.Get<Damage>();
            ref TargetID TargetIDComponent = ref bulletEnity.Get<TargetID>();
            ref Speed SpeedComponent = ref bulletEnity.Get<Speed>();
            ref ID IDComponent = ref bulletEnity.Get<ID>();
            ref TransformRef TransformRefComponent = ref bulletEnity.Get<TransformRef>();

            TargetIDComponent.value = targetID;
            DamageComponent = damage;

            SpeedComponent.value = 5;

            IDComponent.value = SingleTone.objectsCount;
            SingleTone.objectsCount++;

            TransformRefComponent.transform = bullet.transform;
        }
    }
}