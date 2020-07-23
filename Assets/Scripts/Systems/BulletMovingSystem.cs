using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class BulletMovingSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<Bullet, TargetID, TransformRef, Speed> _filterBullet;
        EcsFilter<ID, TransformRef> _filterTargets; 
        
        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterBullet)
            {
                ref TargetID targetIDComponent = ref _filterBullet.Get2(index);
                ref TransformRef transformRefComponent = ref _filterBullet.Get3(index);
                ref Speed speedComponent = ref _filterBullet.Get4(index);

                bool succes = false;

                foreach(var index1 in _filterTargets)
                {
                    ref ID IDComponent = ref _filterTargets.Get1(index1);
                    ref TransformRef targetTransformRefComponent = ref _filterTargets.Get2(index1);

                    if(IDComponent.value == targetIDComponent.value)
                    {
                        Vector3 dir = (targetTransformRefComponent.transform.position - transformRefComponent.transform.position).normalized;

                        transformRefComponent.transform.up = dir;
                        transformRefComponent.transform.Translate(dir * speedComponent.value * Time.deltaTime, Space.World);
                        succes = true;
                    }
                }

                if(!succes)
                {
                    Object.Destroy(transformRefComponent.transform.gameObject);
                    _filterBullet.GetEntity(index).Destroy();
                }
            }
        }
    }
}