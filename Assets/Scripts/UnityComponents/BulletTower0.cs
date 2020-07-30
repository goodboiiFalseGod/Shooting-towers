using Assets;
using Assets.Scripts.UnityComponents;
using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BulletTower0 : TowerBase
{
    public GameObject bullet;
    public Configuration config;

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
        if(SingleTone.IsMouseOccupied)
        {
            bulletTowerEntity.Get<Unplaced>();
        }

        ref Shooter ShooterComponent = ref bulletTowerEntity.Get<Shooter>();
        ref Damage DamageComponent = ref bulletTowerEntity.Get<Damage>();
        ref ID IDComponent = ref bulletTowerEntity.Get<ID>();
        ref TransformRef TransformRefComponent = ref bulletTowerEntity.Get<TransformRef>();
        ref BulletType BulletTypeComponent = ref bulletTowerEntity.Get<BulletType>();
        ref TowerBaseRef TowerBaseRefComponent = ref bulletTowerEntity.Get<TowerBaseRef>();
        ref Price PriceComponent = ref bulletTowerEntity.Get<Price>();

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

        TowerBaseRefComponent.towerBase = this;

        PriceComponent.value = 100;

        string msg = this.name + " initilized with ID " + IDComponent.value.ToString();
        Debug.Log(msg);

        entity = bulletTowerEntity;
    }
}
