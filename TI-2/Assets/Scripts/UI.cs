using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image sanidade;
    public Sprite full;
    public Sprite mid;
    public Sprite empty;
    public Text pontos;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        InvokeRepeating("AddPontos", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.sanity > 10)
        {
            sanidade.sprite = full;
        }
        else if (PlayerController.sanity > 0)
        {
            sanidade.sprite = mid;
        }
        else if(PlayerController.sanity == 0)
        {
            sanidade.sprite = empty;
        }

    }

    void AddPontos()
    {
        score++;
        pontos.text = "Pontuação: " + score;

    }
}
