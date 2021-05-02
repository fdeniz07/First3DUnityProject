using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kure_hareket : MonoBehaviour
{
    private Vector3 yon;
    public float hiz;



    // Start is called before the first frame update
    void Start()
    {
        yon = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (yon.x == 0) //x'e gitmiyor, z yönünde gidiyor
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.forward; //x yönünde gidiyor
            }
        }

        if (Input.GetMouseButton(1))
        {
            if (yon.z == 0) 
            {
                yon = Vector3.right;
            }
            else
            {
                yon = Vector3.down; 
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 kure_move = yon * Time.deltaTime * hiz;
        transform.position += kure_move;
    }
}
