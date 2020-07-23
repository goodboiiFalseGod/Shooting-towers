using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EnemyMovingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Speed, WalkingRoad, TransformRef, Finished> _filterWalking;

        void IEcsRunSystem.Run()
        {
            // add your run code here.
            foreach (var index in _filterWalking)
            {
                ref Speed speedComponent = ref _filterWalking.Get1(index);
                ref WalkingRoad flyingRoadComponent = ref _filterWalking.Get2(index);
                ref TransformRef transformRefComponent = ref _filterWalking.Get3(index);
                ref Finished finishedComponent = ref _filterWalking.Get4(index);

                Vector3 dir = (flyingRoadComponent.points[finishedComponent.value] - transformRefComponent.transform.position).normalized;
                transformRefComponent.transform.right = dir;
                transformRefComponent.transform.Translate(dir * speedComponent.value * Time.deltaTime, Space.World);

                if(finishedComponent.value < flyingRoadComponent.points.Length)
                {
                    if (Vector3.Distance(flyingRoadComponent.points[finishedComponent.value], transformRefComponent.transform.position) < 0.1f)
                    {
                        finishedComponent.value++;
                    }
                }
                if(finishedComponent.value == flyingRoadComponent.points.Length)
                {
                    _filterWalking.GetEntity(index).Get<Ended>();
                }
            }
        }
    }
}   