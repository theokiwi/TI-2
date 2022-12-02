using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWin : MonoBehaviour
{
    public Text pontos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pontos.text = "Pontuação " + GameManager.GM.highScore;
    }
}
