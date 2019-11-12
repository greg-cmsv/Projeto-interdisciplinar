using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tempo : MonoBehaviourPunCallbacks , IPunObservable
{

    public static int tentativas;

    public Text txtTentativas;
    public Text txtplayer;

    // Start is called before the first frame update
    void Start()
    {
        txtplayer.text.ToUpper();
        if (SceneManager.GetActiveScene().name.Equals("Multi"))
            tentativas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (MultiPlayer.jogador == 2)
            txtplayer.text = PhotonNetwork.LocalPlayer.NickName + " adivinhou";
        else
            txtplayer.text = PhotonNetwork.LocalPlayer.NickName + " descobriram";
       
        txtTentativas.text = " em " +tentativas+ " tentativa(s)";
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if(MultiPlayer.jogador == 2)
            {
                stream.SendNext(tentativas);
            }
        }
        else
        {
            tentativas = (int)stream.ReceiveNext();
        }
    }
}
