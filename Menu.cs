using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Single()
    {
       SceneManager.LoadScene("Single");
    }

    public void Multi()
    {
       SceneManager.LoadScene("Multi");
    }

    public void Back()
    {
        if (!Photon.Pun.PhotonNetwork.IsConnected)
            SceneManager.LoadScene("Menu");
        else
            StartCoroutine("Backing");
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Configurar()
    {
        SceneManager.LoadScene("Config");
    }

    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }

    public void Loja()
    {
        SceneManager.LoadScene("Loja");
    }

    public void Sair()
    {
        Application.Quit();
    }

    IEnumerator Backing()
    {
        Photon.Pun.PhotonNetwork.Disconnect();
        MultiPlayer.jogador = 0;
        Tempo.tentativas = 0;

        while (Photon.Pun.PhotonNetwork.IsConnected)
        {
            yield return new WaitForEndOfFrame();
        }

        SceneManager.LoadScene("Menu");
    }

}
