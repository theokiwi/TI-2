using UnityEngine;
/*[Serializable]
    public class PlayerData
{
    public int [] characterCost;
    Criei isso baseado no vídeo do moço, isso funciona como "escolha de salvação"
    E concluir que devo assistir os outros vídeos kjljkj
}*/

public class GameManager : MonoBehaviour
{
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
        characterIndex = charIndex; //isso funciona como seleção, ou seja, a troca
        //SceneManager.LoadScene(cena);
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
