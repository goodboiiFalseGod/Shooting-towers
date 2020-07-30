using Leopotam.Ecs;

namespace Client {
    sealed class ShowShootSystem : IEcsRunSystem {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        EcsFilter<JustShooted, TowerBaseRef> _filterJustShooted;

        void IEcsRunSystem.Run () {
            // add your run code here.
            foreach(var index in _filterJustShooted)
            {
                ref TowerBaseRef towerBaseRefComponent = ref _filterJustShooted.Get2(index);

                towerBaseRefComponent.towerBase.DisplayShoot();

                _filterJustShooted.GetEntity(index).Del<JustShooted>();
            }
        }
    }
}