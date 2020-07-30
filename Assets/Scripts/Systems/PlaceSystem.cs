using Assets;
using Assets.UnityComponents;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Client {
    sealed class PlaceSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Unplaced, Price> _filterUnplaced;
        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterUnplaced)
            {
                ref Price pr = ref _filterUnplaced.Get2(index);

                if(Input.GetMouseButtonDown(0))
                {   if(!EventSystem.current.IsPointerOverGameObject ())
                    {   
                        if(SingleTone.Wallet >= pr.value)
                        {
                            _filterUnplaced.GetEntity(index).Del<Unplaced>();
                            SingleTone.currentrlyHeld = null;
                            SingleTone.IsMouseOccupied = false;

                            SingleTone.Wallet -= pr.value;
                        }
                        else
                        {
                            SingleTone.ui.NotEnoughMoney();
                        }
                    }
                }
            }
        }
    }
}