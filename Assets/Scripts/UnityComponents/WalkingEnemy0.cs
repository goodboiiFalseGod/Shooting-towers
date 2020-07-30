using Assets.Scripts.UnityComponents;
using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy0 : EnemyBase
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

    }

    protected override void CreateEntity()
    {
        EcsEntity WalkingEnemyEntity = SingleTone.mainworld.NewEntity();

        WalkingEnemyEntity.Get<Enemy>();
        WalkingEnemyEntity.Get<Walking>();

        ref Defence DefenceComponent = ref WalkingEnemyEntity.Get<Defence>();
        ref Health HealthComponent = ref WalkingEnemyEntity.Get<Health>();
        ref Speed SpeedComponent = ref WalkingEnemyEntity.Get<Speed>();
        ref RecievedDamage RecievedDamageComponent = ref WalkingEnemyEntity.Get<RecievedDamage>();
        ref ID IDComponent = ref WalkingEnemyEntity.Get<ID>();
        ref TransformRef TransformRefComponent = ref WalkingEnemyEntity.Get<TransformRef>();
        ref WalkingRoad WalkingRoadComponent = ref WalkingEnemyEntity.Get<WalkingRoad>();
        ref Finished FinishedComponent = ref WalkingEnemyEntity.Get<Finished>();
        ref Transparent TransparentComponent = ref WalkingEnemyEntity.Get<Transparent>();
        ref EnemyBaseRef EnemyBaseRefComponent = ref WalkingEnemyEntity.Get<EnemyBaseRef>();
        ref Reward rewardComponent = ref WalkingEnemyEntity.Get<Reward>();

        DefenceComponent.fire = 10;
        DefenceComponent.lightning = 0;
        DefenceComponent.physic = 10;
        DefenceComponent.water = 50;

        HealthComponent.value = 100;

        SpeedComponent.value = 2;

        RecievedDamageComponent.fire = 0;
        RecievedDamageComponent.lightning = 0;
        RecievedDamageComponent.physic = 0;
        RecievedDamageComponent.water = 0;

        IDComponent.value = SingleTone.objectsCount;
        SingleTone.objectsCount++;

        TransformRefComponent.transform = this.transform;

        WalkingRoadComponent.points = SingleTone.WalkingRoad0;

        FinishedComponent.value = 0;

        TransparentComponent.value = 0;

        entity = WalkingEnemyEntity;

        EnemyBaseRefComponent.enemy = this;

        rewardComponent.value = 50;

        string msg = this.name + " initilized with ID " + IDComponent.value.ToString();
        Debug.Log(msg);
    }
}
