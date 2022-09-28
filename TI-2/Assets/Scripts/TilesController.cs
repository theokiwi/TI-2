using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject[] obstacles;

    public void DeactivateAllObstacles()
    {
        for (int i = 0; i < obstacles.Length; i++)
            obstacles[i].SetActive(false);
    }

    public void ActivateRandomObstacle()
    {
        DeactivateAllObstacles();
        int randomNumber = Random.Range(0, obstacles.Length +1);
        obstacles[randomNumber].SetActive(true);
    }
}
