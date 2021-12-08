using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>
/// Classe que controla o funcionamento dos tiles
///</summary>

public class Tile : MonoBehaviour
{
    private bool  tileRevelada = false; //indica se a carta está virada
    public Sprite originalCarta; // Sprite da frente da carta
    public Sprite backCarta; // Sprite do verso da carta vermelha
    public Sprite backCartaAzul; // Sprite do verso da carta azul
    int dificuldade = 0;
    
    /*
        Start is called before the first frame update
    */ 
    void Start()
    {
        dificuldade = PlayerPrefs.GetInt("Dificuldade",0);
        EscondeCarta();
    }

    /*
        Update is called once per frame
    */
    void Update()
    {
        
    }

    /*
        Método que descreve o que fazer quando o mouse passa em cima do tile
    */
    public void OnMouseDown()
    {
        //Se carta já foi revelada, mostra a parte de trás ao clicar na carta
       /* if(tileRevelada)
            EscondeCarta();

        //Caso contrário mostra a frente
        else
            RevelaCarta();*/ // aqui não se guarda o número de cartas
            GameObject.Find("gameManager").GetComponent<ManageCartas>().CartaSelecionada(gameObject);
    }

    /*
        Método que vira a carta mostrando a parte de trás
    */
    public void EscondeCarta()
    {
        if(dificuldade == 1){
        GetComponent<SpriteRenderer>().sprite = backCarta;
        tileRevelada = false;
        }
        if(dificuldade == 0){
        GetComponent<SpriteRenderer>().sprite = backCartaAzul;
        tileRevelada = false;
        }
        else{
             GetComponent<SpriteRenderer>().sprite = backCarta;
        tileRevelada = false;
        }
    }

    /*
        Método que vira a carta mostrando a parte da frente
    */
    public void RevelaCarta()
    {
        GetComponent<SpriteRenderer>().sprite = originalCarta;
        tileRevelada = true; 
    }

    /*
        Seta nova imagem da carta
    */
    public void SetCartaOriginal(Sprite novaCarta)
    {
        originalCarta = novaCarta;
    }
}
