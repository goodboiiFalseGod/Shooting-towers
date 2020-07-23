using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class DeathSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Health, TransformRef> _filter; 
        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filter)
            {
                ref Health healthComponent = ref _filter.Get1(index);
                ref TransformRef transformComponent = ref _filter.Get2(index);

                if(healthComponent.value <= 0)
                {   
                    Object.Destroy( transformComponent.transform.gameObject);
                    _filter.GetEntity(index).Destroy();
                }
            }
        }
    }
}