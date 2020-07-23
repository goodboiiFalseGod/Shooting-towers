using Assets.UnityComponents;
using Client;
using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;
        CreateEntity();
    }

    // Update is called once per frame
    void CreateEntity()
    {
        EcsEntity cityEnity = SingleTone.mainworld.NewEntity();

        cityEnity.Get<Client.City>();

        ref Health healthComponent = ref cityEnity.Get<Health>();

        healthComponent.value = 10000;
    }
}
