using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour {

    private GameObject clon;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject obj = gameObject;
            Vector3 pos = new Vector3(obj.transform.position.x + 91.91f, obj.transform.position.y, obj.transform.position.z);
            clon = Instantiate(obj,pos,Quaternion.identity);
        }
    }
}
