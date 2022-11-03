using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] Players;
     
     void Awake()
     {
        Instantiate(Players[GameManager.GM.characterIndex], transform.position, Quaternion.identity);
     }
}
