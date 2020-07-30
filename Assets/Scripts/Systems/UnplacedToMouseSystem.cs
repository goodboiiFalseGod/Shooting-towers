using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class UnplacedToMouseSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Unplaced, TransformRef> _filterUnplaced;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterUnplaced)
            {
                TransformRef transformRefComponent = _filterUnplaced.Get2(0);
                Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newPos.z = 0;
                transformRefComponent.transform.position = newPos;
            }
        }
    }
}