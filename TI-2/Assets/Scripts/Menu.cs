using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text costText;
    public GameObject[] characters;

    private int characterIndex = 0; //Declarando os personagens
    void Start()
    {
        /*UpdateCoins(GameManager.gm.coins);*/
    }

    void Update()
    {
        
    }
    /*Interessante que aqui ele criou a opção do Button, ou seja
      podemos pegar o script dele e por aqui -além de por no GameManager-,
      e o motivo seria esse:
    public void OnButtonClick(){
        if(GameManager.gm.characterCost[characterIndex] <= GameManager.gm.coins) -> o personagem dele é compravel
        {
            GameManager.gm.coins -= GameManager.gm.characterCost[characterIndex];
            GameManager.gm.characterCost[characterIndex] = 0; -> ele não terá mais preço
            GameManager.gm.Save();
            GameManager.gm.StartRun(characterIndex);
        }
    }*/

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

        /*string cost = "";
          if(GameManager.gm.characterCost[characterIndex] != 0)
             cost = GameManager.gm.characterCost[characterIndex].ToString();
          costText.text = cost;
        Basicamente esse código me permite colocar um preço no personagem
        pórem, acredito que não vamos usar k :)*/
    } //mins Assistir os ep 12
}
