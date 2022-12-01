using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private static UI ui;
    public Image sanidade;
    public Sprite full;
    public Sprite mid;
    public Sprite empty;
    public Text pontos;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        //score = GameManager.GM.pontos;
    }

    public void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        pontos.text = "Pontuação: " + GameManager.GM.pontos;
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

    
}
