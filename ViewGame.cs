using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGame : MonoBehaviour {

	public static ViewGame sharedInstance;

	public Text coinsLabel;

	public Text ScoreLabel;

	public Text highScoreLabel;

	void Awake()
	{
	
		sharedInstance = this;
	
	}




	// Update is called once per frame
	void Update () 
	{
		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame) 
		{
			

			ScoreLabel.text = PlayerController.sharedInstance.GetDistance ().ToString ("f0");


		}
	
	}

	public void UpdatesetHighScoreLabel()
	{
		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame) 
		{
		
			highScoreLabel.text = PlayerPrefs.GetFloat ("highScore", 0).ToString ("f0");
		
		}


	
	
	}

	public void UpdateCoinsLabel()
	{
		if (GameManager.sharedInstance.currentGameState == GameState.inTheGame) 
		{
			coinsLabel.text = GameManager.sharedInstance.recolectaCoin.ToString ();
		
		
		}
	
	
	
	}

}
