using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EnemyFlyingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Speed, FlyingRoad, TransformRef, Finished> _filterFlying;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterFlying)
            {
                ref Speed speedComponent = ref _filterFlying.Get1(index);
                ref FlyingRoad flyingRoadComponent = ref _filterFlying.Get2(index);
                ref TransformRef transformRefComponent = ref _filterFlying.Get3(index);
                ref Finished finishedComponent = ref _filterFlying.Get4(index);

                Vector3 dir = (flyingRoadComponent.finish - transformRefComponent.transform.position).normalized;
                transformRefComponent.transform.right = dir;
                transformRefComponent.transform.Translate(dir * speedComponent.value * Time.deltaTime, Space.World);

                if(Vector3.Distance(flyingRoadComponent.finish, transformRefComponent.transform.position) < 0.1f)
                {
                    _filterFlying.GetEntity(index).Get<Ended>();
                }
            }
        }
    }
}