using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public string cena;
    
    public void OnButtonClick()
    {
        SceneManager.LoadScene(cena);
    }
}
