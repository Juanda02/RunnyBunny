﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dona : MonoBehaviour {


	bool Recogido= false;

	void Showcoin()
	{


		this.GetComponent<SpriteRenderer> ().enabled = true;
		this.GetComponent<CircleCollider2D> ().enabled = true;
		Recogido = false;
	}

	void HideCoin()
	{
		//Ocultar Zanahoria
		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<CircleCollider2D> ().enabled = false;
	}



	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Player") 
		{
			
			Destroy (this.gameObject);
			//PlayerController.runnigspeed -= 1;

		}
	
	
	}




}
