using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClickMenu : MonoBehaviour
{
    public string cena;

    public void OnButtonClick()
    {
        SceneManager.LoadScene(cena);
    }
}
