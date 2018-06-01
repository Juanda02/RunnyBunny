using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class accionesMenu : MonoBehaviour {

	// Use this for initialization


	public void Paso ()
	{
	
		SceneManager.LoadScene ("Principal");

	}

	public void Tienda()
	{
	
		SceneManager.LoadScene ("Tienda");
	
	}
	public void Salir()
	{
	
		Application.Quit ();
	
	}
	public void Tutorial()
	{
	  
		SceneManager.LoadScene ("Aprende");
	
	
	
	}
    public void Creditos()
    {

        SceneManager.LoadScene("Creditos");



    }

    public void Inicio()
	{
	
		SceneManager.LoadScene ("Tutorial");
	
	}
}
