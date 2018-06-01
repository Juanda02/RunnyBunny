using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    private Vector3 pos_inicial;
    private float velocidad;

    // Use this for initialization
    void Start()
    {  
        pos_inicial = transform.position;
        velocidad = PlayerController.runnigspeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            SeguirJugador();
        }

       if( GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            ResetToStartPosition();
        }

       if(PlayerController.runnigspeed > velocidad)
        {
            velocidad = PlayerController.runnigspeed;
            Debug.Log("Camara acelera");
        }
    }

    private void SeguirJugador()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1, transform.position.y,transform.position.z), velocidad * Time.deltaTime);
    }

    public void ResetToStartPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos_inicial, 1000f * Time.deltaTime);
        velocidad = 8f;
    }
}
