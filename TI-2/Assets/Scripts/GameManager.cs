using UnityEngine;
using UnityEngine.SceneManagement;
/*[Serializable]
    public class PlayerData
{
    public int [] characterCost;
    Criei isso baseado no v�deo do mo�o, isso funciona como "escolha de salva��o"
    E concluir que devo assistir os outros v�deos kjljkj
}*/

public class GameManager : MonoBehaviour
{
    private string Inicio;
    private string Hospicio;
    private string Rua;
    //private string Derrota;

    public GameObject Menu;
    bool opecao = false;

    public int[] characterCost; //Quantidade de personagens
    public int characterIndex;

    /*OBS: CASO DE PROBLEMAS NO NOSSO JOGO, ELE INDICOU QUE DEVEMOS EXCLUIR O SAVE
      ALEM DE INFORMAR QUE O GAMEMANAGER NAO E ACONSELHAVEL FICAR NA CENA DO JOGO!!*/
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void StarRun(int charIndex)
    {
        characterIndex = charIndex; //isso funciona como sele��o, ou seja, a troca
        SceneManager.LoadScene(Hospicio);
        //Fazer um if para trocar cena?
    }
    public void OnChooseClick()
    {
        opecao = !opecao;
        Menu.SetActive(opecao);
    }
    public void Save()
    {
        //data.characterCost = new int[characterCost.Length]; -> quantidade de personagens
        /*for (int i = 0; i < data.characterCost.Length; i++)
                data.characterCost[i] = characterCost[i];*/
    }
    void Load()
    {
        /*for (int i = 0; i < characterCost.Length; i++)
                characterCost[i] = data.characterCost[i];*/
    }
}
