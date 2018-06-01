using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour {

	public static ViewGameOver sharedInstance;
	public Text coinsLabel;

	public Text ScoreLabel;


	void Awake()
	{
		sharedInstance = this;
	
	
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	
	
	}

	public void UpdateUi()
	{
		if (GameManager.sharedInstance.currentGameState == GameState.gameOver) 
		{
			coinsLabel.text = GameManager.sharedInstance.recolectaCoin.ToString ();
			ScoreLabel.text = PlayerController.sharedInstance.GetDistance ().ToString ("F0");



		}if (GameManager.sharedInstance.currentGameState == GameState.gameOver) 
		{
			GameManager.sharedInstance.recolectaCoin = 0;
		
		}
	
	}
}
