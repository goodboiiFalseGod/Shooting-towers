using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class Control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {;
            this.transform.Rotate(transform.forward * 0.5f);
        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(transform.right * Time.deltaTime * 3, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {;
            this.transform.Rotate(-transform.forward * 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-transform.right * Time.deltaTime * 3, Space.World);
        }
    }
}
