using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mensajes : MonoBehaviour {

    [SerializeField]
    private GameObject ex;
    [SerializeField]
    private GameObject inc;
    [SerializeField]
    private GameObject muy;
    [SerializeField]
    private Transform point;
    [SerializeField]
    private int tiempo_texto;
    [SerializeField]
    private AudioClip sonido;
    [SerializeField]
    private int monedas_para_mensaje = 0;

    private int score = 0;
    private GameObject obj;
    private bool activar_contador = false;
    private int contador = 0;
    private Vector3 posIn;
    private AudioSource reproductor;
   

	// Use this for initialization
	void Start ()
    {
        reproductor = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (score ==  monedas_para_mensaje)
        {
            Seleccionar();
            activar_contador = true;
            score = 0;
        }

        if(activar_contador)
        {
            contador++;

            if(contador == tiempo_texto)
            {
                obj.transform.position = posIn;
                contador = 0;
                activar_contador = false;
            }
        }
	}

    private void Seleccionar()
    {
        float i = Random.Range(1,4);
        Mathf.Round(i);
       
        if(i == 1)
        {
            obj = inc;
            posIn = obj.transform.position;
            obj.transform.position = point.position;
        }

        if (i == 2)
        {
            obj = ex;
            posIn = obj.transform.position;
            obj.transform.position = point.position;
        }

        if (i == 3)
        {
            obj = muy;
            posIn = obj.transform.position;
            obj.transform.position = point.position;
        }

        reproductor.clip = sonido;
        reproductor.Play();
        Debug.Log("numero del random: " + i);
    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            score += 1;
        }
    }
}
