using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerTriger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D theObject)
	{
		if (theObject.tag == "Player") 
		{
			theObject.gameObject.GetComponent<PlayerController> ().KillPlayer ();
		
		}
	
	}
}
