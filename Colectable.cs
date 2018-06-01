using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectable : MonoBehaviour {

    bool iscollected = false;
	public AudioSource music;
	public ParticleSystem ps;

	void Showcoin()
	{

		this.GetComponent<SpriteRenderer> ().enabled = true;
		this.GetComponent<CircleCollider2D> ().enabled = true;
		iscollected = false;

	}

	 void HideCoin()
	{
	    //Ocultar Moneda
		this.GetComponent<SpriteRenderer> ().enabled = false;
		this.GetComponent<CircleCollider2D> ().enabled = false;

	}

	void CollectCoin()
	{
		iscollected = true;
		HideCoin ();
		//Notificar al manager que hemos recogido la moneda
		GameManager.sharedInstance.CollectCoin();
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Player") 
		{			
			CollectCoin ();
			ps.Play ();
			music.Play ();
	
		}
		
	}
}
