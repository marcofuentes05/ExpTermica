using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VaraScript : MonoBehaviour
{
    public Canvas canvas;

    //Texturas de los materiales
    public Texture acero;
    public Texture aluminio;
    public Texture laton;
    public Texture cobre;
    public Texture vidrio;
    public Texture invar;
    public Texture cuarzo;

    //Coeficientes de expansión lineal de los materiales (alfa) en (°C^-1)
    private float cAluminio = 0.000024f;
    private float cLaton = 0.000020f;
    private float cCobre = 0.000017f;
    private float cVidrio = 0.000070f; //Es el promedio
    private float cInvar = 0.0000009f;
    private float cCuarzo = 0.000004f;
    private float cAcero = 0.000012f;

    private float coeficienteActual = 0f;
    public float lInicial;
    private float lFinal;
    public float deltaT;
    private float deltaL;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<Renderer>().material.mainTexture = acero;
        }
    }

    //Imagino que numero es el indice del elemento seleccionado de la lista
    public void cambiarMaterial(int numero)
    {
        if (numero == 0)
        {
            GetComponent<Renderer>().material.mainTexture = acero;
        }
        else if (numero == 1)
        {
            GetComponent<Renderer>().material.mainTexture = aluminio;
        }
        else if (numero == 2)
        {
            GetComponent<Renderer>().material.mainTexture = cobre;
        }
        else if (numero == 3)
        {
            GetComponent<Renderer>().material.mainTexture = cuarzo;
        }
        else if (numero == 4)
        {
            GetComponent<Renderer>().material.mainTexture = laton;
        }
        else if (numero == 5)
        {
            GetComponent<Renderer>().material.mainTexture = vidrio;
        }
    }
}
