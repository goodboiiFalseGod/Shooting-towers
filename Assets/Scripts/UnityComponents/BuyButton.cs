using Assets;
using Assets.UnityComponents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public GameObject tower;
    public Button yourButton;
    public Configuration config;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(Spawn);
    }

    // Update is called once per frame
    public void Spawn()
    {   
        if(!SingleTone.IsMouseOccupied)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            SingleTone.IsMouseOccupied = true;
            SingleTone.currentrlyHeld = Instantiate(tower, pos, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            Destroy(SingleTone.currentrlyHeld);
            SingleTone.IsMouseOccupied = false;
        }
    }
}
