using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BulletTower0 : GameEntity
{
    public GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void CreateEntity()
    {
        EcsEntity bulletTowerEntity = SingleTone.mainworld.NewEntity();

        bulletTowerEntity.Get<CanShootFlying>();
        bulletTowerEntity.Get<CanShootWalking>();
        bulletTowerEntity.Get<Tower>();
        bulletTowerEntity.Get<IsShootBullet>();

        ref Shooter ShooterComponent = ref bulletTowerEntity.Get<Shooter>();
        ref Damage DamageComponent = ref bulletTowerEntity.Get<Damage>();
        ref ID IDComponent = ref bulletTowerEntity.Get<ID>();
        ref TransformRef TransformRefComponent = ref bulletTowerEntity.Get<TransformRef>();
        ref BulletType BulletTypeComponent = ref bulletTowerEntity.Get<BulletType>();

        ShooterComponent.cooldown = 2;
        ShooterComponent.currentCooldown = 0;
        ShooterComponent.range = 5;
        ShooterComponent.targetsIDs = new int[1];
        for(int i = 0; i < ShooterComponent.targetsIDs.Length; i++)
        {
            ShooterComponent.targetsIDs[i] = -1;
        }

        DamageComponent.fire = 10;
        DamageComponent.lightning = 0;
        DamageComponent.physic = 10;
        DamageComponent.water = 0;

        IDComponent.value = SingleTone.objectsCount;
        SingleTone.objectsCount++;

        TransformRefComponent.transform = this.transform;

        BulletTypeComponent.bullet = bullet;

        string msg = this.name + " initilized with ID " + IDComponent.value.ToString();
        Debug.Log(msg);

        entity = bulletTowerEntity;
    }
}
