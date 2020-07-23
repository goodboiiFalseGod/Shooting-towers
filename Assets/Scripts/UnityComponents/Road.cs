using Assets.UnityComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] childrens =  new Vector3[transform.childCount];
        SingleTone.WalkingRoad0 = childrens;
        for (int i = 0; i < childrens.Length; i++)
        {
            childrens[i] = transform.GetChild(i).position;
        }
    }

    // Update is called once per frame
    [ContextMenu("CreatePoint")]
    public void CreatePoint()
    {
        GameObject pointObj = Object.Instantiate(point, this.transform);
        pointObj.name = "Point" + transform.childCount.ToString();
    }
}
