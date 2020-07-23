using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class CheckAreInRangeSystem : IEcsRunSystem {
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

                    bool[] succes = new bool[shooterComponent.targetsIDs.Length];

                    for (int i = 0; i < shooterComponent.targetsIDs.Length; i++)
                    {
                        succes[i] = false;

                        if (shooterComponent.targetsIDs[i] == IDcomponent.value)
                        {
                            float dis = Vector3.Distance(towerTransformRefComponent.transform.position, enemyTransformRefComponent.transform.position);

                            if(dis > shooterComponent.range)
                            {
                                shooterComponent.targetsIDs[i] = -1;
                            }

                            succes[i] = true;
                        }

                        if(!succes[i])
                        {
                            shooterComponent.targetsIDs[i] = -1;
                        }
                    }
                }
            }
        }
    }
}