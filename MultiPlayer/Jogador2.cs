using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Jogador2 : MonoBehaviourPunCallbacks, IPunObservable
{

    [HideInInspector] public int[] senha;

    [HideInInspector] public int senhaAtual;

    [SerializeField] int[] senhaPass;

    // Start is called before the first frame update
    void Start()
    {
        senhaAtual = 0;
        senhaPass = new int[4];
        senha = new int[4];
        for (int i = 0; i < senha.Length; i++)
        {
            senha[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Pronto())
        {
            AcertarOrdem();
        }
    }

    public bool Pronto()
    {
        int cont = 0;
        for (int i = 0; i < senha.Length; i++)
        {
            if (senha[i] != 0) cont++;
        }

        if (cont == senha.Length)
        {
            PhotonNetwork.SetMasterClient(Senha.photonPlayers[1]);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Add(int value)
    {
        if (senhaAtual < senha.Length)
        {
            senha[senhaAtual] = value;
            senhaPass[senhaAtual] = value;
            senhaAtual++;
        }
    }

    void AcertarOrdem()
    {
        if (senha[senhaAtual] != 0)
            senhaAtual++;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            if (MultiPlayer.jogador == 2)
            {
                stream.SendNext(senhaPass);

            }
        }
        else
        {
            if (stream.IsReading)
                senha = (int[])stream.ReceiveNext();

        }

    }
}
