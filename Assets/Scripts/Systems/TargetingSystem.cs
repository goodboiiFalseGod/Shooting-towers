using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class TargetingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Enemy, TransformRef, ID> _filterFlyingEnemy;
        EcsFilter<Tower, Shooter, TransformRef> _filterTower;

        void IEcsRunSystem.Run()
        {
            // add your run code here.
            foreach (var index in _filterTower)
            {
                ref Shooter shooterComponent = ref _filterTower.Get2(index);
                ref TransformRef towerTransformRefComponent = ref _filterTower.Get3(index);

                foreach (var index1 in _filterFlyingEnemy)
                {
                    ref ID IDcomponent = ref _filterFlyingEnemy.Get3(index1);
                    ref TransformRef enemyTransformRefComponent = ref _filterFlyingEnemy.Get2(index1);

                    Vector3 dir = Vector3.zero;

                    for (int i = 0; i < shooterComponent.targetsIDs.Length; i++)
                    {
                        if(shooterComponent.targetsIDs[i] == IDcomponent.value)
                        {
                            dir += (enemyTransformRefComponent.transform.position - towerTransformRefComponent.transform.position).normalized;

                            towerTransformRefComponent.transform.up = dir;
                        }
                    }
                }
            }
        }
    }
}