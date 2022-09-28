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

    List<TilesController> spawnedTiles = new List<TilesController>();
    public static TilesGenerator Instance;

    private void Start()
    {
        Instance = this;

        Vector3 spawnPos = startPoint.position;
        for (int i = 0; i < tilesPreSpawn; i++) 
        {
            spawnPos -= tilePrefab.startPoint.position;
            TilesController currentTile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
            currentTile.ActivateRandomObstacle();
            spawnPos = currentTile.endPoint.position;
            currentTile.transform.SetParent(transform);
            spawnedTiles.Add(currentTile);
        }
    }

    private void Update()
    {
        transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * moveSpeed);

        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).x < 0)
        {
            TilesController tileTemp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0);
            tileTemp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTemp.startPoint.localPosition;
            tileTemp.ActivateRandomObstacle();
            spawnedTiles.Add(tileTemp);
        }
    }

}
