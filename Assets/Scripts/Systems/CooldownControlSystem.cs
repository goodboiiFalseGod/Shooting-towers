using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class CooldownControlSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Shooter> _filterShooter;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterShooter)
            {
                ref Shooter shooterComponent = ref _filterShooter.Get1(index);

                if(shooterComponent.currentCooldown >= 0)
                {
                    shooterComponent.currentCooldown -= 1 * Time.deltaTime;
                }
            }
        }
    }
}