using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public GameObject botoes;
    public GameObject players;
    public GameObject dificuldade;
    public GameObject novo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        //dificuldade.SetActive(true);
        //novo.SetActive(false);
        // players.SetActive(true);
        // botoes.SetActive(false);
        SceneManager.LoadScene("Multi");
    }
}
