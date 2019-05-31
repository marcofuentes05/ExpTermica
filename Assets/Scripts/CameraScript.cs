using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public Slider Li;
    public Slider AT;
    public Text LiT;
    public Text ATT;
    public Text coeficiente;
    public Text longitudFinal;
    public GameObject cilindro;
    public GameObject c2;

    int material;
    float lf;
    float Al; //El delta L

    private float cAluminio = 0.000024f;
    private float cLaton    = 0.000020f;
    private float cCobre    = 0.000017f;
    private float cVidrio   = 0.000070f; //Es el promedio
    private float cCuarzo   = 0.000004f;
    private float cAcero    = 0.000012f;

    //Para saber cuando animar la barra
    private bool animation = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LiT.gameObject.GetComponent<Text>().text = Li.value + " m";
        ATT.gameObject.GetComponent<Text>().text = AT.value + " K";

        cilindro.gameObject.GetComponent<Transform>().localScale = new Vector3(1, Li.value, 1);
        c2.gameObject.GetComponent<Transform>().localScale = new Vector3(1, Li.value, 1);
        if (animation)
        {
            cilindro.gameObject.GetComponent<Transform>().localScale += new Vector3(0,Al*10,0);
            //animation = false;
        }
        if (cilindro.gameObject.GetComponent<Transform>().localScale == new Vector3 (1,lf*100,1)){
            animation = false;
        }
    }

    public void setCoeficiente(int numero)
    {
        material = numero;
        if (numero == 0)
        {
            coeficiente.gameObject.GetComponent<Text>().text = "="+cAcero.ToString()+" /°C";
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

    //TODO el codigo onClick() del boton de Aplicar
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

        

        string text = " = " + lf.ToString();

        longitudFinal.gameObject.GetComponent<Text>().text = text;
    }

    public void cambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
