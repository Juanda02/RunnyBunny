using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Slider slider;

	public static PlayerController sharedInstance;

	public float jumpForce = 5.0f;
	private Rigidbody2D rigidBody;
	public static float runnigspeed = 8.0f;

	public LayerMask groundLayerMas;
	public Animator animator;

	private Vector3 startPosition;

	private string highScoreKey = "highScore";

	public static int cont = 0;
    private float indice = 0;
    private Animator anim;


	void Awake ()
	{   
		animator.SetBool ("isAlive", true);
		sharedInstance = this;
		rigidBody = GetComponent<Rigidbody2D> ();
		startPosition = this.transform.position;

        slider.value = slider.value / 2;
        indice = slider.value;
        anim = GetComponentInChildren<Animator>();
	}

	public void StartGame () 
	{
		animator.SetBool ("isAlive", true);
		this.transform.position = startPosition;
		rigidBody.velocity = new Vector2 (0, 0);
		anim.SetInteger ("Estado", 0);
	}

	void Update () 
	{

		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame) {
			if (Input.GetMouseButtonDown (0)) {
				jump ();
			}
		
			animator.SetBool ("isGrounded", IsOnTheFloor ());
		}
	}

	void FixedUpdate()
	{
		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame) {

			if (rigidBody.velocity.x < runnigspeed) {
		
				rigidBody.velocity = new Vector2 (runnigspeed, rigidBody.velocity.y);
		
			}
		}

      if(indice > 0.7f)
        {
            anim.SetInteger("Estado", 1);
        }
        if(indice < 0.3f)
        {
            anim.SetInteger("Estado", 2);
        }
        if(indice > 0.4f && indice < 0.6f)
        {
            anim.SetInteger("Estado", 0);
        }
	
	}
	void jump ()
	{

		if (IsOnTheFloor ()) 
		{
			rigidBody.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}

	bool IsOnTheFloor()
	{
		if (Physics2D.Raycast (this.transform.position, Vector2.down, 1.0f, groundLayerMas.value)) {
			return true;
	
		} else 
		{
			return false;
		}
	}

	public void KillPlayer()
	{
		GameManager.sharedInstance.GameOver ();
		animator.SetBool ("isAlive", false);
        slider.value = 1f;
        slider.value = slider.value / 2;
	    
		if(PlayerPrefs.GetFloat(highScoreKey, 0) < this.GetDistance())
		{
			PlayerPrefs.SetFloat (highScoreKey, this.GetDistance ());

		}
	}

	public float GetDistance()
	{
		float distanceTraveled = Vector2.Distance (new Vector2 (startPosition.x, 0), new Vector2 (this.transform.position.x, 0));
	    
		return distanceTraveled;
	
	}


	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		if (otherCollider.tag == "Lento") 
		{		   
			cont ++;
            slider.value -= 0.05f;
            indice -= 0.05f;

        } if (cont > 5)

        {		   
			runnigspeed -= 5;

			Debug.Log (cont);	
		}

        if (otherCollider.tag == "kill")
        {
            KillPlayer();
        }

        if (otherCollider.tag == "Zana")
        {
            slider.value += 0.05f;
            indice += 0.05f;
        }
}
}
