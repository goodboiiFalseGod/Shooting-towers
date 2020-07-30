using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : GameEntity
{
    // Start is called before the first frame update

    // Update is called once per frame
    protected override void CreateEntity()
    {
        EcsEntity cityEnity = SingleTone.mainworld.NewEntity();

        ref WalletC healthComponent = ref cityEnity.Get<WalletC>();

        healthComponent.value = 100;

        SingleTone.Wallet = 100;
    }
}
