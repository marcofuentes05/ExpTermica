﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSPlano : MonoBehaviour
{
    /*Literalmente es el archivo CameraScript, pero adaptado a una expansion en 2d*/
    public Slider Li;
    public Slider AT;
    public Text LiT;
    public Text ATT;
    public Text coeficiente;
    public Text longitudFinal;
    public GameObject plano;

    int material;
    float lf;
    float Al; //El delta L

    private float cAluminio = 0.000024f;
    private float cLaton = 0.000020f;
    private float cCobre = 0.000017f;
    private float cVidrio = 0.000070f; //Es el promedio
    private float cCuarzo = 0.000004f;
    private float cAcero = 0.000012f;

    //Para saber cuando animar la barra
    public bool animation = false;
    // Start is called before the first frame update
    void Start()
    {
        /*Multiplico los coeficientes por dos, porque es una expansion de area, no lineal*/
        cAluminio = 2 * cAluminio;
        cLaton = 2 * cLaton;
        cCobre = 2 * cCobre;
        cVidrio = 2 * cVidrio;
        cCuarzo = 2 * cCuarzo;
        cAcero = 2 * cAcero;

    }

    // Update is called once per frame
    void Update()
    {
        LiT.gameObject.GetComponent<Text>().text = Li.value + " m";
        ATT.gameObject.GetComponent<Text>().text = AT.value + " K";

        plano.gameObject.GetComponent<Transform>().localScale = new Vector3(Li.value, 1, Li.value);

        if (animation)
        {
            plano.gameObject.GetComponent<Transform>().localScale += new Vector3(Al * 100, 0, Al * 100);
        }
        if (plano.gameObject.GetComponent<Transform>().localScale == new Vector3(lf * 100, 1,lf*100))
        {
            animation = false;
        }
    }

    public void setCoeficiente(int numero)
    {
        material = numero;
        if (numero == 0)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cAcero.ToString() + " /°C";
        }
        else if (numero == 1)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cAluminio.ToString() + " /°C";
        }
        else if (numero == 2)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cCobre.ToString() + " /°C";
        }
        else if (numero == 3)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cCuarzo.ToString() + " /°C";
        }
        else if (numero == 4)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cLaton.ToString() + " /°C";
        }
        else if (numero == 5)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "=" + cVidrio.ToString() + " /°C";
        }
    }

    //El codigo onClick() del boton de Aplicar
    public void onClick()
    {
        if (material == 0)
        {
            lf = Li.value * AT.value * cAcero;
        }
        else if (material == 1)
        {
            lf = Li.value * AT.value * cAluminio;
        }
        else if (material == 2)
        {
            lf = Li.value * AT.value * cCobre;
        }
        else if (material == 3)
        {
            lf = Li.value * AT.value * cCuarzo;
        }
        else if (material == 4)
        {
            lf = Li.value * AT.value * cLaton;
        }
        else if (material == 5)
        {
            lf = Li.value * AT.value * cVidrio;
        }
        Al = lf;
        lf += Li.value;

        animation = true;

        string text = " = " + lf.ToString() + "m2";

        longitudFinal.gameObject.GetComponent<Text>().text = text;
    }
}
