using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int person;
    static public int pontos;

    void Start()
    {
        GM = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (PlayerController.health < 1)
        {
            Death();
        }
        InvokeRepeating("AddPontos", 10.0f, 10.0f);
    }
    void Death()
    {
       SceneManager.LoadScene(3);
    }

    void AddPontos()
    {
        pontos++;
        PlayerPrefs.SetInt("score", pontos);

    }
    /*void Record()
    {
        if(health = 0 && recorde == true)
        {
            SceneManager.LoadScene(Vitoria);
        }
    }*/

}


