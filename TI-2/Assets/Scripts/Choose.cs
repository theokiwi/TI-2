using UnityEngine;
using UnityEngine.UI;

public class Choose : MonoBehaviour
{
    public GameObject Menu;
    bool opecao = false;
    public void OnChooseClick()
    {
        opecao = !opecao;
        Menu.SetActive(opecao);
    }
}
