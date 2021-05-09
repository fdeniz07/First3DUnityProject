using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class yol_olustur : MonoBehaviour
{
    public GameObject son_yol;

    void Start()
    {
        for (int i = 0; i < 10; i++) //10 adet yol olustur
        {
           yol_olusturma();
        }
    }

    void Update()
    {

    }

    public void yol_olusturma()
    {
        Vector3 yon;
        if (Random.Range(0, 2) == 0)
        {
            yon=Vector3.forward;
        }
        else
        {
            yon=Vector3.left;
        }
        //instantiate = clone yapmaya yarar
        //kopyalanacak nesne   , nereye kopyalayacak, nesnenin acisal konumu

        son_yol = Instantiate(son_yol, son_yol.transform.position + yon, son_yol.transform.rotation);

        // son_yol = Instantiate(son_yol, son_yol.transform.position + Vector3.forward, son_yol.transform.rotation); // calisma zamaninda projeye yeni nesne ekleme komutu +z yönünde

    }
}
