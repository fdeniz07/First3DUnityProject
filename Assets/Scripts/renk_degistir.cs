using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renk_degistir : MonoBehaviour
{
    public Color[] renklerimiz;
    Color renk2;
    public Material yol_malzemesi;
    int renk_secimi;

    void Start()
    {
        renk_secimi = Random.Range(0, 3);
        if (renk_secimi == 1)
        {
            yol_malzemesi.color = renklerimiz[renk_secimi];
            renk2 = renklerimiz[renk_secimi + 1];
        }
    }

    void Update()
    {
        //renk degistirici
        yol_malzemesi.color = Color.Lerp(yol_malzemesi.color, renk2, 0.05f);
    }

}
