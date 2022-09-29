using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint;
    public TilesController tilePrefab;
    public float moveSpeed = 8;
    public int tilesPreSpawn = 5;
    public int tilesNoObstacle = 3; //Sem obstaculos no início do jogo

    List<TilesController> spawnedTiles = new List<TilesController>();
    public static TilesGenerator Instance;

    private void Start()
    {
        Instance = this;

        Vector3 spawnPos = startPoint.position;
        int tilesNoObstacleTemp = tilesNoObstacle;

        for (int i = 0; i < tilesPreSpawn; i++) 
        {
            spawnPos -= tilePrefab.startPoint.position;
            TilesController currentTile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
            if (tilesNoObstacle > 0)
            {
                currentTile.DeactivateAllObstacles();
                tilesNoObstacleTemp--;
            }else
                currentTile.ActivateRandomObstacle();

            spawnPos = currentTile.endPoint.position;
            currentTile.transform.SetParent(transform);
            spawnedTiles.Add(currentTile);
        }
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * (- spawnedTiles[0].transform.forward)); //apenas mudei de ordem, mas o problema continua

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).x < -0.3f) //no dele ele colocou negativo ao inves -erros ;-;- de 0
        {
            TilesController tileTemp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTemp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTemp.startPoint.localPosition;
            tileTemp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTemp);
        }
    }

}
