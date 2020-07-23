using Assets.UnityComponents;
using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class CityDamageSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Health, Ended, TransformRef> _filterEnded;
        EcsFilter<City, Health> _filterCity;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterCity)
            {
                ref Health HealthComponent = ref _filterCity.Get2(index);

                foreach(var index1 in _filterEnded)
                {
                    ref Health EndedHealthComponent = ref _filterEnded.Get1(index);
                    ref TransformRef TransformRefComponent = ref _filterEnded.Get3(index);
                    HealthComponent.value -= EndedHealthComponent.value;

                    Object.Destroy(TransformRefComponent.transform.gameObject);
                    _filterEnded.GetEntity(index).Destroy();

                    SingleTone.HealthOfCity = HealthComponent.value;
                }
            }
        }
    }
}