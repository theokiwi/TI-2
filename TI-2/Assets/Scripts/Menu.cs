using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string cena;
    public void BtnNico()
    {
        GameManager.GM.person = 0;
        SceneManager.LoadScene(cena);
    }
    public void BtnAlice()
    {
        GameManager.GM.person = 1;
        SceneManager.LoadScene(cena);
    }
}
