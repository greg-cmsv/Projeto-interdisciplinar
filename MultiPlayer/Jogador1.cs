using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Jogador1 : MonoBehaviourPunCallbacks, IPunObservable
{
    
    [HideInInspector] public int[] senha;

    [HideInInspector] public int senhaAtual;

    [SerializeField] int[] senhaPass;

    // Start is called before the first frame update
    void Start()
    {
        senhaAtual = 0;
        senha = new int[4];
        senhaPass = new int[4];
        for (int i = 0; i < senha.Length; i++)
        {
            senha[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
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

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

        if (stream.IsWriting)
        {
            stream.SendNext(senhaPass[0]);
            stream.SendNext(senhaPass[1]);
            stream.SendNext(senhaPass[2]);
            stream.SendNext(senhaPass[3]);

        }
        else
        {
            if (stream.IsReading)
            {
                senha[0] = (int)stream.ReceiveNext();
                senha[1] = (int)stream.ReceiveNext();
                senha[2] = (int)stream.ReceiveNext();
                senha[3] = (int)stream.ReceiveNext();

            }
        }
    }
}

