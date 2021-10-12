using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool  tileRevelada = false; //indica se a carta está virada
    public Sprite originalCarta; // Sprite da frente da carta
    public Sprite backCarta; // Sprite do verso da carta

    // Start is called before the first frame update
    void Start()
    {
        EscondeCarta();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método que descreve o que fazer quando o mouse passa em cima do tile
    public void OnMouseDown()
    {
        //Se carta já foi revelada, mostra a parte de trás ao clicar na carta
        if(tileRevelada)
            EscondeCarta();

        //Caso contrário mostra a frente
        else
            RevelaCarta();
    }

    //Método que vira a carta mostrando a parte de trás
    public void EscondeCarta()
    {
        GetComponent<SpriteRenderer>().sprite = backCarta;
        tileRevelada = false;
    }

    //Método que vira a carta mostrando a parte da frente
    public void RevelaCarta()
    {
        GetComponent<SpriteRenderer>().sprite = originalCarta;
        tileRevelada = true; 
    }

    //Seta nova imagem da carta
    public void SetCartaOriginal(Sprite novaCarta)
    {
        originalCarta = novaCarta;
    }
}
