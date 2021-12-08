using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
///<summary>
/// Classe que controla os botoes do menu
///</summary>

public class MenuManager : MonoBehaviour
{
    /*
        Metodo que define o modo de jogo 1
    */
    public void DificuldadeUm(){
        PlayerPrefs.SetInt("Dificuldade", 1);
        SceneManager.LoadScene("Lab3");
    }

    /*
        Metodo que define o modo de jogo 0
    */
    public void DificuldadeZero(){
        PlayerPrefs.SetInt("Dificuldade", 0);
        SceneManager.LoadScene("Lab3");
    }

    /*
        Metodo que define o modo de jogo 2
    */
    public void DificuldadeDois(){
        PlayerPrefs.SetInt("Dificuldade", 2);
        SceneManager.LoadScene("Lab3");
    }

    /*
        Metodo que define o modo de jogo 3
    */
    public void DificuldadeTres(){
        PlayerPrefs.SetInt("Dificuldade", 3);
        SceneManager.LoadScene("Lab3");
    }
}
