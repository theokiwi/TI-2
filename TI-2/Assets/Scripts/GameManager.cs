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
    public bool aliveYet = true;
    public bool faseDois = false;
    public bool faseUm = true;
    private bool ispause = false;

    void Start()
    {
        GM = this;
        DontDestroyOnLoad(gameObject);
        aliveYet = true;
        faseUm = true;
        faseDois = false;
    }

    void Update()
    {
        if (PlayerController.health < 1)
        {
            if (aliveYet == true)
            {
                dead = true;
                if (pontos < maiorPonto)
                {
                    Death();
                    aliveYet = false;
                    PlayerController.health = 1;
                }
                else if (pontos > maiorPonto)
                {
                    maiorPonto = pontos;
                    recorde = true;
                    Record();
                    aliveYet = false;
                    PlayerController.health = 1;
                }
            }

            if (faseUm == true)
            {
                if (pontos > 30)
                {
                    ChangeScene();
                    faseUm = false;
                }
            }

        }
        InvokeRepeating("AddPontos", 10.0f, 10.0f);
    }
    void Death()
    {
       SceneManager.LoadScene(3);
       pontos = pontoAnterior;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(2);
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
    /*public void SetPause(bool P)
    {
        ispause = P;
        if (ispause)
            Time.timeScale = 0.0f;
        else
            Time.timeScale = 1.0f;
    }*/
}


