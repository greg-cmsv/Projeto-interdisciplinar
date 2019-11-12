using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Config : MonoBehaviour
{
    public static int type;
    public static int musica;

    public Image som;
    public Image tipo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mudo()
    {
        if (musica == 0)
        {
            musica = 1;
            som.GetComponentInChildren<Text>().text = "Music: Off";
            som.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/desligado");
        }
        else
        {
            musica = 0;
            som.GetComponentInChildren<Text>().text = "Music: On";
            som.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/ligado");
        }
    }

    public void Tipo()
    {
        if (type == 0)
        {
            type = 1;
            tipo.GetComponentInChildren<Text>().text = "Type: Forms";
            tipo.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/pentagono");
        }
        else
        {
            type = 0;
            tipo.GetComponentInChildren<Text>().text = "Type: Colors";
            tipo.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/circulo-preto");
        }
    }

}
