using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int person;
    static public int pontos;
    static public int pontoAnterior;
    static public int maiorPonto = int.MinValue;
    public bool recorde = false;
    public bool dead = false;

    void Start()
    {
        GM = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (PlayerController.health < 1)
        {
            dead = true;
            if (pontos < maiorPonto)
            {
                Death();
            }
            else if (pontos > maiorPonto)
            {
                maiorPonto = pontos;
                recorde = true;
                Record();
            }
        }
        InvokeRepeating("AddPontos", 10.0f, 10.0f);


    }
    void Death()
    {
       SceneManager.LoadScene(3);
       pontos = pontoAnterior;
    }

    void AddPontos()
    {
        pontos++;
    }
    void Record()
    {
        if(dead && recorde)
        {
            SceneManager.LoadScene(4);
        }
    }

}


