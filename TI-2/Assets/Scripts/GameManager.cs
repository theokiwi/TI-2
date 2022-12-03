using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public int person;
    public int pontos;

    static public int pontoAnterior;
    static public int maiorPonto = int.MinValue;

    public bool recorde = false;
    public bool dead = false;
    public bool aliveYet = true;
    public int highScore;

    public GameObject ispause;
    void Start()
    {
        GM = this;
        aliveYet = true;
        InvokeRepeating("AddPontos", 1.0f, 1.0f);
 
    }

 
            
        
    
    void Update()
    {
        if (pontos > 150)
        {
            SceneManager.LoadScene(2);
            pontos = 151;
        }

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

        }
  
    }
    public void Death()
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
        PlayerPrefs.SetInt("score", pontos);

    }
    void Record()
    {
        if (dead && recorde)
        {
            SceneManager.LoadScene(4);
            highScore = pontos;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
    public void Pause()
    {
        ispause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        ispause.SetActive(false);
        Time.timeScale = 1f;
    }
}


