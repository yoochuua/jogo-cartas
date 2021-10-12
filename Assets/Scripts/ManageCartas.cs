using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ManageCartas : MonoBehaviour
{
    public GameObject carta; // Carta a ser descartada
    public GameObject novaCarta;

    // Start is called before the first frame update
    void Start()
    {
        MostraCartas();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Método que cria uma quantidade x de cartas
    void MostraCartas()
    {
        int[] arrayEmbaralhado = criaArrayEmbaralhado();
        int[] arrayEmbaralhado1 = criaArrayEmbaralhado();
        for (int i = 0; i < 13; i++)
        {
            AddUmaCarta(0, i, arrayEmbaralhado[i]);
            AddUmaCarta(1, i, arrayEmbaralhado1[i]);
        }
        
    }

    //Cria uma carta com as cartacteristicas segundo o parametro passado
    void AddUmaCarta(int linha, int valor, int rank)
    {
        GameObject centro  = GameObject.Find("centroDaTela");
        float escalaCartaOriginal = carta.transform.localScale.x;
        float fatorEscalaX = (650*escalaCartaOriginal)/110.0f;
        float fatorEscalaY = (945*escalaCartaOriginal)/110.0f;
        Vector3 novaPosicao = new Vector3(centro.transform.position.x + (( valor - 13 / 2) * fatorEscalaX), centro.transform.position.y + (( linha - 2 / 2) * fatorEscalaY), centro.transform.position.z);
        GameObject c = (GameObject)(Instantiate(carta, novaPosicao, Quaternion.identity));
        
        //Encotrar a carta de acordo com o rank
        c.tag = "" + rank;
        c.name = "" + linha +" "+ rank;
        string nomeDaCarta = "";
        string numeroDaCarta = "";
        if (rank == 0)
            numeroDaCarta = "ace";
        else if (rank == 10)
            numeroDaCarta = "jack";
        else if (rank == 11)
            numeroDaCarta = "queen";
        else if (rank == 12)
            numeroDaCarta = "king";
        else
            numeroDaCarta = "" + (rank + 1);
        
        nomeDaCarta = numeroDaCarta + "_of_clubs";
        Sprite s1 = (Sprite)(Resources.Load<Sprite>(nomeDaCarta)); //Encontra a imagem da carta no resources
        GameObject.Find("" + linha + " " +rank).GetComponent<Tile>().SetCartaOriginal(s1); // Seta no tile criado
    }
    public int[] criaArrayEmbaralhado()
    {
        int[] novoArray = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        int temp;
        for (int i = 0; i < 13; i++)
        {
            temp = novoArray[i];
            int r = Random.Range(i, 13);
            novoArray[i] = novoArray[r];
            novoArray[r] = temp;
        }
        return novoArray;
    }

}
