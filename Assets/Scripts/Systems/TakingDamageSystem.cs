using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class TakingDamageSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<RecievedDamage, Defence, Health> _filterDamaged;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterDamaged)
            {
                ref RecievedDamage recievedDamageComponent = ref _filterDamaged.Get1(index);
                ref Defence defenceComponent = ref _filterDamaged.Get2(index);
                ref Health healthComponent = ref _filterDamaged.Get3(index);

                float FinDmg = 0;

                FinDmg += recievedDamageComponent.fire - (recievedDamageComponent.fire * defenceComponent.fire / 100);
                FinDmg += recievedDamageComponent.lightning - (recievedDamageComponent.lightning * defenceComponent.lightning / 100);
                FinDmg += recievedDamageComponent.physic - (recievedDamageComponent.physic * defenceComponent.physic / 100);
                FinDmg += recievedDamageComponent.water - (recievedDamageComponent.water * defenceComponent.water / 100);

                healthComponent.value -= FinDmg;

                recievedDamageComponent.fire = 0;
                recievedDamageComponent.lightning = 0;
                recievedDamageComponent.physic = 0;
                recievedDamageComponent.water = 0;
            }
        }
    }
}