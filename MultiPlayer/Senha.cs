using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Senha : MonoBehaviourPunCallbacks, IPunObservable
{
    public Jogador1 j1;
    public Jogador2 j2;
    public Text detalhe;
    public Text player;

    public Image[] senhaImage;
    [SerializeField] int[] senhaPass;
    
    bool verificando;
    bool gambiarra;
    public static Player[] photonPlayers;

    //public Text recebendo;

    // Start is called before the first frame update
    void Start()
    {
        senhaPass = new int[4];
        verificando = true;
        gambiarra = true;
        player.text.ToUpper();
        player.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        photonPlayers = PhotonNetwork.PlayerList;
        AcertarCor();

        if (j2.Pronto() && verificando)
        {
            Verificar();
            if(gambiarra)
                Tempo.tentativas++;
        }
        else
        {
           
        }



        if (MultiPlayer.jogador == 2)
        {
            Debug.Log("EU SOU O MESTRE 2: " + PhotonNetwork.IsMasterClient);
            detalhe.text = "Você deve advinhar a senha!";
            player.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            Debug.Log("EU SOU O MESTRE 1: " + PhotonNetwork.IsMasterClient);
            detalhe.text = "Você deve criar a senha!";
            player.text = PhotonNetwork.LocalPlayer.NickName;
        }
    }

    public void Verificar()
    {
        verificando = false;
        bool dChange = true;

        for (int i = 0; i < j2.senha.Length; i++)
        {
            if (senhaPass[i] < 2)
            {
                senhaPass[i] = 0;
            }

            for (int j = 0; j < j1.senha.Length; j++)
            {
                if (j2.senha[i] == j1.senha[j])
                {
                    if (i == j)
                    {
                        senhaPass[i] = 2;
                        dChange = false;
                    }
                    else
                    {
                        if (dChange)
                        {
                            senhaPass[i] = 1;
                            dChange = false;
                        }
                    }
                }
                else
                {
                    if (dChange)
                    {
                        senhaPass[i] = 0;
                    }
                }

            }
            AcertarCor();

            dChange = true;
            if(j2.senha[i] != j1.senha[i])
                j2.senha[i] = 0;
        }
        j2.senhaAtual = 0;

        verificando = true;


    }

    void AcertarCor()
    {
        int cont = 0;

        for (int i = 0; i < senhaPass.Length; i++)
        {
            if (senhaPass[i] == 2)
            {
                senhaImage[i].sprite = Resources.Load<Sprite>("Sprites/preto");
                senhaImage[i].color = Color.white;
                Debug.ClearDeveloperConsole();
                cont++;
            }
            else if (senhaPass[i] == 1)
            {
                senhaImage[i].sprite = Resources.Load<Sprite>("Sprites/branco1");
                senhaImage[i].color = Color.white;
                Debug.ClearDeveloperConsole();
            }
            else if (senhaPass[i] < 1)
            {
                senhaImage[i].sprite = Resources.Load<Sprite>("Sprites/branco1");
                Color cor = new Color();
                cor.r = 0.5568628f;
                cor.g = 0.5568628f;
                cor.b = 0.5568628f;
                cor.a = 1;
                senhaImage[i].color = cor;
                Debug.ClearDeveloperConsole();
            }
        }

        if (cont == senhaPass.Length)
        {
            if (gambiarra) Tempo.tentativas++;
            gambiarra = false;
            StartCoroutine(Sinc());
        }
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            if (MultiPlayer.jogador == 2)
            {
                stream.SendNext(senhaPass[0]);
                stream.SendNext(senhaPass[1]);
                stream.SendNext(senhaPass[2]);
                stream.SendNext(senhaPass[3]);
                Debug.Log("Madou pacote SENHA");
            }
        }
        else
        {
            Debug.Log("Recebeu o pacote SENHA");
            //recebendo.text = "Recebendo: " + stream.IsReading;

            senhaPass[0] = (int)stream.ReceiveNext();
            senhaPass[1] = (int)stream.ReceiveNext();
            senhaPass[2] = (int)stream.ReceiveNext();
            senhaPass[3] = (int)stream.ReceiveNext();

            //j1.senhaAtual = 0;
            //PhotonNetwork.SetMasterClient(photonPlayers[0]);
        }
    }

    IEnumerator Sinc()
    {
        yield return new WaitForSecondsRealtime(3);
        PhotonNetwork.LoadLevel("Win");
    }
}
