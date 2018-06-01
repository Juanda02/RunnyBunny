using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftBlockTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
	
		GeneradorDeNiveles.sharedInstance.AddNewBlock ();
		GeneradorDeNiveles.sharedInstance.RemoveOldBlock ();
	
	}
}
