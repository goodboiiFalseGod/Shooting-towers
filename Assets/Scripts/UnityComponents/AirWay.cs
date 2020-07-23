using Assets.UnityComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirWay : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform finish;

    // Update is called once per frame
    private void Start()
    {
        SingleTone.FlyingRoad0 = new Vector3[1];
        SingleTone.FlyingRoad0[0] = new Vector3(finish.position.x, finish.position.y, finish.position.z);
    }
}
