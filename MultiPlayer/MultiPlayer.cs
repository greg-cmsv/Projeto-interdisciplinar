using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class MultiPlayer : MonoBehaviourPunCallbacks
{
    public Button conectar;
    public Image image;
    public GameObject confirmar;
    public GameObject senha;
    public GameObject player;
    public GameObject cores, temp;
    public GameObject tempo;
    public GameObject tabuleiro;
    public GameObject detalhe;

    //public GameObject name;
    public InputField nome;

    public static int jogador;

    void Awake()
    {
        nome.characterLimit = 13;
        nome.text.ToUpper();
        nome.text = "Player " + Random.Range(1000, 10000);
    }

    // Start is called before the first frame update
    void Start()
    {

        //temp = Instantiate(cores);  
    }

        // Update is called once per frame
    void Update()
    {
        //Debug.Log("Conectado: " + PhotonNetwork.IsConnected);
        //Debug.Log("Lobby: " +PhotonNetwork.InLobby);
        //Debug.Log("Room: " + PhotonNetwork.InRoom);
        //Debug.Log("Jogador: " + PhotonNetwork.CountOfPlayers);
        //if(PhotonNetwork.InRoom)
        //    Debug.Log("RoomJog: " + PhotonNetwork.CurrentRoom.PlayerCount);

        //texto.text = "EU SOU O JOGADOR: " + jogador;

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string sala = "Room" + Random.Range(0.0f, 10000.0f);
        RoomOptions opcoesSala = new RoomOptions();
        opcoesSala.MaxPlayers = 2;
        BotaoJogo.pronto = false;

        PhotonNetwork.CreateRoom(sala,opcoesSala);
        PhotonNetwork.JoinRoom(sala);

    }

    public override void OnJoinedRoom()
    {
        Confirma();

        jogador = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public void Conecta()
    {
       StartCoroutine(Conectar());
    }

    

    public void Confirma()
    {
        image.gameObject.SetActive(false);
        player.SetActive(false);
        confirmar.SetActive(false);

        tempo.SetActive(true);

        tabuleiro.SetActive(true);
        cores.SetActive(true);
        senha.SetActive(true);
        //detalhe.SetActive(true);

    }

    IEnumerator Conectar()
    {
        string playerName = nome.text;

        PhotonNetwork.LocalPlayer.NickName = playerName;
        Debug.Log(playerName);
        int cont = 0;
        while(!PhotonNetwork.IsConnected && cont < 3)
        {
            PhotonNetwork.ConnectUsingSettings();
            cont++;
            yield return new WaitForSecondsRealtime(2);
        }

        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            nome.gameObject.SetActive(false);
            conectar.gameObject.SetActive(false);
        }

    }
}
