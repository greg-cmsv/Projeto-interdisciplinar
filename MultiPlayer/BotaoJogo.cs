using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class BotaoJogo : MonoBehaviourPunCallbacks, IPunObservable
{
    public Jogador1 j1;
    public Jogador2 j2;
    public static bool pronto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pronto = j1.Pronto();
        Debug.Log("Pronto: " + pronto);

        if (MultiPlayer.jogador == 2)
        {
            if (!pronto)
            {
                GetComponent<Button>().interactable = false;
            }
            else
            {
                GetComponent<Button>().interactable = true;
            }
        }

    }

    public void Add(int value)
    {
        Tabuleiro temp = FindObjectOfType<Tabuleiro>();
        if (MultiPlayer.jogador == 1)
        {
            if (j1.senhaAtual < j1.senha.Length)
            {
                j1.Add(value);
                temp.Atualizar(j1.senha);
            }
        }
        else
        {
            j2.Add(value);
            temp.Atualizar(j2.senha);
        }
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
