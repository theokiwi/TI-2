using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    public Transform startPoint; // GameObject marcando o início do tile
    public Transform endPoint; // GameObject marcando o final do tile
    public GameObject[] obstacles; // Lista de obstáculos




    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles(); // Desliga todos os obstáculos antes de ligar um aleatoriamente

        int randomNumber = Random.Range(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
        
    }

    public void DeactivateAllObstacles() // Desliga todos os obstáculos
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }

   
    
    private void ChangeSide()
    {
        int myDirection = Random.Range(0, 2);
        
        /**switch(TilesDirection) vai encaixar no start
        {
            case 0:
            mudar a rotacao do currentTile?
            case 1:

            case 2:
        }**/

    }

}
