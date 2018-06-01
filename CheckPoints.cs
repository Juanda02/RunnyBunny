using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	public AudioClip music;
	public AudioSource efecto;


	void Start()
	{
	
		efecto.clip = music;
	
	
	}

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Player") 
		{
			/*efecto.Play ();
			PlayerController.runnigspeed += 2;
			Destroy (this.gameObject);*/



		
		}
}

	}
