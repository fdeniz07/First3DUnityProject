using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kure_hareket : MonoBehaviour
{
    private Vector3 yon;
    public float hiz;
    public yol_olustur yol_olusturuyoruz;
    public static bool fall;
    public Text sokorummuz; 
    int skor;
    public Text en_yuksek_skorumuz;
    public int en_yuksek_skor;

    // Start is called before the first frame update
    void Start()
    {
        yon = Vector3.forward;
        fall = false;
        en_yuksek_skor = PlayerPrefs.GetInt("enyuksekskor");
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

        //if (Input.GetMouseButton(1))
        //{
        //    if (yon.z == 0)
        //    {
        //        yon = Vector3.right;
        //    }
        //    else
        //    {
        //        yon = Vector3.down;
        //    }
        //}

        if (transform.position.y <-0.5f)
        {
            Destroy(this.gameObject);
            fall = true;
            if (en_yuksek_skor<skor)
            {
                en_yuksek_skor = skor;
                PlayerPrefs.SetInt("enyuksekskor",en_yuksek_skor);
                en_yuksek_skorumuz.text = en_yuksek_skor.ToString();
            }
        }
    }

    void FixedUpdate()
    {
        if (fall)
        {
            return;
        }

        if ((skor%5 ==0) && (skor!=0))
        {
            hiz += 0.005f;
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
            skor++;
            sokorummuz.text = skor.ToString();

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
