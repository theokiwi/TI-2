using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    public Transform startPoint; // GameObject marcando o in�cio do tile
    public Transform endPoint; // GameObject marcando o final do tile
    public GameObject[] obstacles; // Lista de obst�culos

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles(); // Desliga todos os obst�culos antes de ligar um aleatoriamente

        int randomNumber = Random.Range(0, obstacles.Length);
        obstacles[randomNumber].SetActive(true);
    }

    public void DeactivateAllObstacles() // Desliga todos os obst�culos
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].SetActive(false);
        }
    }
}
