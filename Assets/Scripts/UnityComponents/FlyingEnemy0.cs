using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy0 : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        CreateEntity();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateEntity()
    {
        EcsEntity flyingEnemyEntity = SingleTone.mainworld.NewEntity();

        flyingEnemyEntity.Get<Enemy>();
        flyingEnemyEntity.Get<Flying>();

        ref Defence DefenceComponent = ref flyingEnemyEntity.Get<Defence>();
        ref Health HealthComponent = ref flyingEnemyEntity.Get<Health>();
        ref Speed SpeedComponent = ref flyingEnemyEntity.Get<Speed>();
        ref RecievedDamage RecievedDamageComponent = ref flyingEnemyEntity.Get<RecievedDamage>();
        ref ID IDComponent = ref flyingEnemyEntity.Get<ID>();
        ref TransformRef TransformRefComponent = ref flyingEnemyEntity.Get<TransformRef>();
        ref FlyingRoad flyingRoadComponent = ref flyingEnemyEntity.Get<FlyingRoad>();
        ref Finished FinishedComponent = ref flyingEnemyEntity.Get<Finished>();
        ref Transparent TransparentComponent = ref flyingEnemyEntity.Get<Transparent>();

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

        flyingRoadComponent.finish = SingleTone.FlyingRoad0[0];

        FinishedComponent.value = 0;

        TransparentComponent.value = 0;

        string msg = this.name + " initilized with ID " + IDComponent.value.ToString();
        Debug.Log(msg);
    }
}
