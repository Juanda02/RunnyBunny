using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
	menu,
	inTheGame,
	gameOver,
	tienda
}








public class GameManager : MonoBehaviour {
	//Juego arranca en el Menu
	public GameState currentGameState = GameState.menu;

	public static GameManager sharedInstance;
	public Canvas menuCanvas;
	public Canvas gameCanvas;
	public Canvas gameOver;
	public Canvas tienda;

	public int recolectaCoin = 0;

	void Awake()
	{
	
		sharedInstance = this;
	}


	void Start()
	{
		currentGameState = GameState.menu;
		menuCanvas.enabled = true;
		gameCanvas.enabled = false;
		gameOver.enabled = false;
		tienda.enabled = false;
	
	}

	void Update()
	{
	
		if (Input.GetButtonDown ("s")) 
		{
			if (currentGameState != GameState.inTheGame) {

				StartGame ();
		
			}
		}
	
	}


	// Use this start the Game
	public void StartGame () 
	{
		PlayerController.sharedInstance.StartGame();
		GeneradorDeNiveles.sharedInstance.GenerateInitialBlocks ();
		ChangeGameState (GameState.inTheGame);
		ViewGame.sharedInstance.UpdatesetHighScoreLabel ();
	
	}
	// Cuando el jugador Muere
	public void GameOver()
	{
		GeneradorDeNiveles.sharedInstance.RemoveAllTheBlocks ();
		ChangeGameState (GameState.gameOver);
		ViewGameOver.sharedInstance.UpdateUi ();
	
	}

	// cuando el jugador decide finalizar y volver a iniciar
	public void BackToMainMenu ()
	{
		ChangeGameState (GameState.menu);
	
	
	}

	void ChangeGameState(GameState NewGameState)
	{
		if (NewGameState == GameState.menu) {
			// La escena debera mostrar el menu principal
			menuCanvas.enabled = true;
			gameCanvas.enabled = false;
			gameOver.enabled = false;
			tienda.enabled = false;
		
		} else if (NewGameState == GameState.inTheGame) {
			// La escena debera ir al juego
			menuCanvas.enabled = false;
			gameCanvas.enabled = true;
			gameOver.enabled = false;
			tienda.enabled = false;
		
		} else if (NewGameState == GameState.gameOver) 
		{
		  // Debe mostrar fin de la partida
			menuCanvas.enabled = false;
			gameCanvas.enabled = false;
			gameOver.enabled = true;
			tienda.enabled = true;
			PlayerController.runnigspeed = 8.0f;
			PlayerController.cont = 0;

		
		}
	
		currentGameState = NewGameState;
	}

	public void CollectCoin()
	{
	
		recolectaCoin++;
		ViewGame.sharedInstance.UpdateCoinsLabel ();
	
	}


}
