using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDeathScreenLost1 : MonoBehaviour
{
    public Text pontoScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pontoScore.text = "Pontuação " + GameManager.GM.pontos;
    }
}
