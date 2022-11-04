using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public GameObject Menu;
    bool opecao = false;
    public string cena;
    public void OnChooseClick()
    {
        opecao = !opecao;
        Menu.SetActive(opecao);
    }
    public void OnButtonClick()
    {
        SceneManager.LoadScene(cena);
    }
}
