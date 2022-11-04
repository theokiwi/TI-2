using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Person1;
    public GameObject Person2;
    void Start()
    {
        if (GameManager.GM.person == 0)
        {
            Instantiate(Person1, transform.position, Quaternion.identity);
        }
        if (GameManager.GM.person == 1)
        {
            Instantiate(Person2, transform.position, Quaternion.identity);
        }
    }
}
