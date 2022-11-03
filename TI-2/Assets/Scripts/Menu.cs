using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text costText;
    public GameObject[] characters;
    public string cena; //estou colocando aqui de forma improvisada

    private int characterIndex = 0; //Declarando os personagens
    void Start()
    {
        //UpdateCoins(GameManager.GM.coins);
        //GameManager.GM.Save();
    }

    void Update()
    {
        
    }
    /*Interessante que aqui ele criou a op��o do Button, ou seja
      podemos pegar o script dele e por aqui -al�m de por no GameManager-,
      e o motivo seria esse:*/
    public void OnButtonClick(){
        SceneManager.LoadScene(cena);
        //GameManager.GM.Save();
       // GameManager.GM.StarRun(characterIndex);

        /*if (GameManager.GM.characterCost[characterIndex] <= GameManager.GM.coins) // o personagem dele � compravel
        {
            GameManager.GM.coins -= GameManager.GM.characterCost[characterIndex];
            GameManager.GM.characterCost[characterIndex] = 0; //ele n�o ter� mais pre�o
            GameManager.GM.Save();
            GameManager.GM.StarRun(characterIndex);
        }*/
    }

    public void ChangeCharacter(int index) //Sele��o de personagens
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
        Basicamente esse c�digo me permite colocar um pre�o no personagem
        p�rem, acredito que n�o vamos usar k :)*/
    } 
}
