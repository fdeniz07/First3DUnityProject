using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kure_hareket : MonoBehaviour
{
    private Vector3 yon;
    public float hiz;
    public yol_olustur yol_olusturuyoruz;
    public static bool fall;


    // Start is called before the first frame update
    void Start()
    {
        yon = Vector3.forward;
        fall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (yon.x == 0) //x'e gitmiyor, z y�n�nde gidiyor
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.forward; //x y�n�nde gidiyor
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

        if (transform.position.y <-0.5f)
        {
            Destroy(this.gameObject);
            fall = true;
        }
    }

    void FixedUpdate()
    {
        if (fall)
        {
            return;
        }

        Vector3 kure_move = yon * Time.deltaTime * hiz;
        transform.position += kure_move;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "yolum")
        {
            StartCoroutine(Yoket(collision.gameObject));
            yol_olusturuyoruz.yol_olusturma();
        }
    }

    //void Yoket(GameObject yok_edilecek_Yol)
    //{
    //    Destroy(yok_edilecek_Yol);
    //}

    IEnumerator Yoket(GameObject yok_eilecek_yol)
    {
        yield return new WaitForSeconds(0.5F);
        yok_eilecek_yol.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(1.2f);
        Destroy(yok_eilecek_yol);
    }
}
