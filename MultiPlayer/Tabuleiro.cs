using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tabuleiro : MonoBehaviour
{

    public Image[] image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Atualizar(int[] senha)
    {
        for (int i = 0; i < image.Length; i++)
        {
            image[i].sprite = GetSprite(senha[i]);
            if (senha[i] != 0)
            {
                image[i].color = Color.white;
            }
            else
            {
                Color cor = new Color();
                cor.r = 0.5568628f;
                cor.g = 0.5568628f;
                cor.b = 0.5568628f;
                cor.a = 1;
                image[i].color = cor;
            }
        }

    }

    public Sprite GetSprite(int value)
    {
        switch (value)
        {
            case 0:
                return Resources.Load<Sprite>("Sprites/branco1");
                
            case 1:
                return Resources.Load<Sprite>("Sprites/vermelho");
                
            case 2:
                return Resources.Load<Sprite>("Sprites/azul");
                
            case 3:
                return Resources.Load<Sprite>("Sprites/amarelo");
                
            case 4:
                return Resources.Load<Sprite>("Sprites/verde");
                
            case 5:
                return Resources.Load<Sprite>("Sprites/roxo");
                
            case 6:
                return Resources.Load<Sprite>("Sprites/laranja");
                
        }

        return null;
    }
}
