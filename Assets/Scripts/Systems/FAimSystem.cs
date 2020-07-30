using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class FAimSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Enemy, TransformRef, ID, Flying> _filterFlyingEnemy;
        EcsFilter<Tower, Shooter, CanShootFlying, TransformRef>.Exclude<Unplaced> _filterTower;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterTower)
            {
                ref Shooter shooterComponent = ref _filterTower.Get2(index);
                ref TransformRef towerTransformRefComponent = ref _filterTower.Get4(index);

                foreach(var index1 in _filterFlyingEnemy)
                {
                    ref ID IDcomponent = ref _filterFlyingEnemy.Get3(index1);
                    ref TransformRef enemyTransformRefComponent = ref _filterFlyingEnemy.Get2(index1);

                    for(int i = 0; i < shooterComponent.targetsIDs.Length; i++)
                    {
                        if(shooterComponent.targetsIDs[i] == -1)
                        {   
                            float dis = Vector3.Distance(towerTransformRefComponent.transform.position, enemyTransformRefComponent.transform.position);

                            if(dis < shooterComponent.range)
                            {
                                shooterComponent.targetsIDs[i] = IDcomponent.value;
                            }
                        }
                    }
                }
            }
        }
    }
}