using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneradorDeNiveles : MonoBehaviour {

	/*
	 * Variables publicas de nuestro generador de niveles
	 * 
	 */


	public static GeneradorDeNiveles sharedInstance; //Instancia compartida para solo tener un generador de niveles
	public List<LevelBlock> allTheLevelBlocks = new List <LevelBlock> (); // Lista que contiene todos los niveles que ha creado
	public List<LevelBlock> currentLevelBlocks = new List <LevelBlock> (); // Lista de los bloques que se tienen en pantalla
	public Transform levelInitialPoint; // Punto inicial donde empezará a crearse el primer nivel de todos

	private bool isGenerateinitialBlock = false;

	void Awake()
	{
		sharedInstance = this;

	
	
	}

	// Use this for initialization
	void Start () 
	{
		GenerateInitialBlocks ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GenerateInitialBlocks()
	{
		isGenerateinitialBlock = true;

		for (int i = 0; i < 3; i++) 
		{
			AddNewBlock ();
		
		
		}
	
		isGenerateinitialBlock = false;
	
	}



	public void AddNewBlock()
	{
	  //Seleccionar un bloque aleatorio entre los disponibles
		int randomIndex = Random.Range(0,allTheLevelBlocks.Count);
	    
		if (isGenerateinitialBlock) 
		{
			randomIndex = 0;
		
		}
		LevelBlock block = (LevelBlock) Instantiate (allTheLevelBlocks [randomIndex]);
		block.transform.SetParent (this.transform, false);

		//Posición del bloque
		Vector3 BlockPosition = Vector3.zero;

		if (currentLevelBlocks.Count == 0) {
		
			// Colocar el primer Bloque en Pantalla
			BlockPosition = levelInitialPoint.position;

		
		} else {
		    // Ya hay bloques y lo empalmo con el ultimo disponible
			BlockPosition = currentLevelBlocks [currentLevelBlocks.Count - 1].exitPoint.position;

		}
		block.transform.position = BlockPosition;
		currentLevelBlocks.Add (block);
	}


	public void RemoveOldBlock()
	{
		LevelBlock block = currentLevelBlocks [0];
		currentLevelBlocks.Remove (block);
		Destroy (block.gameObject);
	
	
	}

	public void RemoveAllTheBlocks()
	{
		while (currentLevelBlocks.Count > 0) 
		{
			RemoveOldBlock ();
		
		
		}
	
	
	}

}
