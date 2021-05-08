using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yol_olustur : MonoBehaviour
{
    public GameObject son_yol;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
           yol_olusturma();
        }
    }

    // Update is called once per frame
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

        son_yol = Instantiate(son_yol, son_yol.transform.position + yon, son_yol.transform.rotation);

        // son_yol = Instantiate(son_yol, son_yol.transform.position + Vector3.forward, son_yol.transform.rotation); // calisma zamaninda projeye yeni nesne ekleme komutu +z yönünde

    }
}
