using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class ManageCartas : MonoBehaviour
{
    public GameObject carta; // Carta a ser descartada
    public GameObject novaCarta;
    private bool primeiraCartaSelecionada, segundaCartaSelecionada; //indicadores para cada carta escolhida em cada linha
    private GameObject carta1, carta2; //gameObjects da 1 e 2 carta selecionada
    private string linhaCarta1, linhaCarta2; // linhas das cartas
    bool timerPausado,timerAcionado; // indicador de pausa
    float timer;//tempo
    int numTentativas = 0; // numero de tentativas na rodada
    int numAcertos = 0; // numero de acertos na rodada
    public AudioSource[] sons = new AudioSource[3]; // sons da tela
    int ultimoJogo = 0; // tentaivas da ultima jogada
    int recorde = 0; // recorde do jogo
    int dificuldade = 0; // dificuldade do game escolhida
    // Start is called before the first frame update
    void Start()
    {
        MostraCartas();
        UpdateTentativas();
        //somOK = GetComponent<AudioSource>();
        ultimoJogo = PlayerPrefs.GetInt("Jogadas", 0);
        recorde = PlayerPrefs.GetInt("Recorde",0);
        dificuldade = PlayerPrefs.GetInt("Dificuldade",0);
        GameObject.Find ("Restart").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find ("FinalizarJogo").transform.localScale = new Vector3(0, 0, 0);
        GameObject.Find("ultimaJogada").GetComponent<Text>().text = "Jogo Anterior = " + ultimoJogo;
        GameObject.Find("recorde").GetComponent<Text>().text = "Recorde = " + recorde;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerAcionado){
            timer += Time.deltaTime ;
            print(timer);
            if(timer>1){
                timerPausado = true;
                timerAcionado = false;
                if(carta1.tag == carta2.tag){
                    Destroy(carta1);
                    Destroy(carta2);
                    numAcertos++;
                    //somOK.Play();
                    sons[0].Play();
                    if(numAcertos ==13){
                        PlayerPrefs.SetInt("Jogadas",numTentativas);
                         if(numTentativas > recorde || recorde == 0){
                             sons[2].Play();
                             PlayerPrefs.SetInt("Recorde",numTentativas);
                            GameObject.Find("novoRecorde").GetComponent<Text>().text = "Parabens!!!! Novo Record de " + recorde + " pontos";
                         }
                         else{
                              sons[3].Play();
                              GameObject.Find("novoRecorde").GetComponent<Text>().text = "infelimente você não atingiu um novo recorde";
                         }
                        GameObject.Find ("Restart").transform.localScale = new Vector3(1, 1, 1);
                        GameObject.Find ("FinalizarJogo").transform.localScale = new Vector3(1, 1, 1);
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
                else{
                    sons[1].Play();
                   carta1.GetComponent<Tile>().EscondeCarta();
                    carta2.GetComponent<Tile>().EscondeCarta();
                }
                primeiraCartaSelecionada = false;
                segundaCartaSelecionada = false;
                carta1 = null;
                carta2 = null;
                linhaCarta1 = "";
                linhaCarta2 = "";
                timer = 0;
            }
        }
    }
    /*função que reinicia o jogo*/
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*botão que leva para a tela de fim de game*/
    public void telaCreditos(){
        SceneManager.LoadScene("Creditos");
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
    public void CartaSelecionada (GameObject carta){
        if(!primeiraCartaSelecionada){
            string linha = carta.name.Substring(0,1);
            linhaCarta1 = linha;
            primeiraCartaSelecionada = true;
            carta1 = carta;
            carta1.GetComponent<Tile>().RevelaCarta();
        }
        else if ( primeiraCartaSelecionada && !segundaCartaSelecionada ){
            string linha = carta.name.Substring(0,1);
            linhaCarta2 = linha;
            segundaCartaSelecionada = true;
            carta2 = carta;
            carta2.GetComponent<Tile>().RevelaCarta();
            VerificaCartas();
        }
    }

    public void VerificaCartas(){
        DisparaTimer();
        numTentativas++;
        UpdateTentativas();
    }

    public void DisparaTimer(){
        timerPausado = false;
        timerAcionado = true;
    }
    void UpdateTentativas(){
        GameObject.Find("numTentativas").GetComponent<Text>().text = "Tentativas = " + numTentativas;
    }
}
