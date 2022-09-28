using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text costText;
    public GameObject[] characters;

    private int characterIndex = 0; //Declarando os personagens
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeCharacter(int index) //Seleção de personagens
    {
        characterIndex += index;
        if (characterIndex >= characters.Length)
            characterIndex = 0;
        else if (characterIndex < 0)
            characterIndex = characters.Length - 1;
        for (int i = 0; i < characters.Length; i++)
        {
            if (i == characterIndex)
                characters[i].SetActive(true);
            else
                characters[i].SetActive(false);
        }
    } //mins Assistir os ep 12, 14
}
