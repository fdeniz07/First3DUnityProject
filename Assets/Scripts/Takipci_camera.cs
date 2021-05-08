using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takipci_camera : MonoBehaviour
{

    public Transform takip_edilen;
    public Vector3 mesafe;


    void Start()
    {
        mesafe = transform.position - takip_edilen.position;

    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (kure_hareket.fall)
        {
            return;
        }
        transform.position = takip_edilen.position + mesafe;
    }
}
