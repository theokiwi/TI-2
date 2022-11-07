using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGenerator : MonoBehaviour
{
    public Camera mainCamera;
    public Transform startPoint; // Onde o jogo deve come�ar
    public TilesController tilesPrefab;
    public float moveSpeed = 12;
    public int tilesPreSpawn = 5; // Quantidade de tiles que eu quero ter sempre em cena
    public int tilesNoObstacle = 3; // Quantidade de tiles sem obst�culos no in�cio do jogo


    List<TilesController> spawnedTiles = new List<TilesController>(); // Lista de tiles


    public static TilesGenerator Instance;

    private void Start()
    {
        Instance = this;
        Vector3 spawnPos = startPoint.position;
        int tilesNoObstacleTemp = tilesNoObstacle;

        for (int i = 0; i < tilesPreSpawn; i++)
        {
            spawnPos -= tilesPrefab.startPoint.position; // Calcula a diferen�a do offset do tile
            TilesController currentTile = Instantiate(tilesPrefab, spawnPos, Quaternion.identity); // de onde sai o currentTile
            if (tilesNoObstacle > 0)
            {
                currentTile.DeactivateAllObstacles();
                tilesNoObstacleTemp--;
            }
            else
            {
                currentTile.ActivateRandomObstacle();
            }
            spawnPos = currentTile.endPoint.position; // Posi��o para criar o pr�ximo tile
            currentTile.transform.SetParent(transform); // Tiles viram filhos do objeto
            spawnedTiles.Add(currentTile); // Adiciona o tile na lista
        }
                                                   
    }

    private void Update()
    {
        transform.Translate(-spawnedTiles[0].transform.forward * Time.deltaTime * moveSpeed); // Move este objeto para frente

        // Esse if verifica se o objeto 0 da lista (o primeiro) passou da vis�o da c�mera no eixo X negativo,
        // ou seja, se ele est� � esquerda da c�mera, fora da �rea de renderiza��o
        if (mainCamera.WorldToViewportPoint(spawnedTiles[0].endPoint.position).z < -0.3f)
        {
            // Move o tile pra frente se ele tiver sa�do da c�mera
            TilesController tileTemp = spawnedTiles[0];
            spawnedTiles.RemoveAt(0); // Remove o tile da lista
            // Reposiciona o tile fora da vis�o da c�mera e o coloca no final
            tileTemp.transform.position = spawnedTiles[spawnedTiles.Count - 1].endPoint.position - tileTemp.startPoint.localPosition;
            tileTemp.ActivateRandomObstacle(); // Ativa um obst�culo aleat�rio
            spawnedTiles.Add(tileTemp); // Readiciona o tile � lista (no final)
        }
    }

}
