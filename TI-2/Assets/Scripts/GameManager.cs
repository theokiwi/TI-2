using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
//using Random = UnityEngine.Random;
//ele colocou isso porque tinha outro script com essa definicao, assim nao teria problema
[Serializable]
    public class PlayerData
    {
    public int [] characterCost;
    /*Criei isso baseado no vídeo do moço, isso funciona como "escolha de salvação"
    E concluir que devo assistir os outros vídeos kjljkj*/
    }



public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public GameObject Menu;
    static public int pontos;

    public int[] characterCost; //Quantidade de personagens
    public int characterIndex;
    private string filePath; //caminho do arquivo

    /*OBS: CASO DE PROBLEMAS NO NOSSO JOGO, ELE INDICOU QUE DEVEMOS EXCLUIR O SAVE
      ALEM DE INFORMAR QUE O GAMEMANAGER NAO E ACONSELHAVEL FICAR NA CENA DO JOGO!!*/
    void Start()
    {
       
    }

    void Update()
    {
        if (PlayerController.health < 1)
        {
            Death();
        }
        InvokeRepeating("AddPontos", 10.0f, 10.0f);
    }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/playerInfor.data";
        if (File.Exists(filePath))
            Load();
    }
    public void StarRun(int charIndex)
    {
        characterIndex = charIndex; //isso funciona como seleção, ou seja, a troca
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath); //cria o caminho
        PlayerData data = new PlayerData();
        /*toda vez que queremos colocar algo para ser salvo vai ser assim: data.Infor = new int[] -caso seja vetor- ou Infor
         Logo depois, temos que os por dentro de um for*/
        data.characterCost = new int[characterCost.Length]; //quantidade de personagens
        for (int i = 0; i < data.characterCost.Length; i++)
            data.characterCost[i] = characterCost[i];
        bf.Serialize(file, data); //pega as informacoes
        file.Close(); //finaliza os comandos
    }
    void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filePath, FileMode.Open); //abri o caminho
        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();

        for (int i = 0; i < characterCost.Length; i++)
            characterCost[i] = data.characterCost[i];
    }
   
    void Death()
    {
       SceneManager.LoadScene(3);
    }

    void AddPontos()
    {
        pontos++;
    }
    /*void Record()
    {
        if(health = 0 && recorde == true)
        {
            SceneManager.LoadScene(Vitoria);
        }
    }*/

}


