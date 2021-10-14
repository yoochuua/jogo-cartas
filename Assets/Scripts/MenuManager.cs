using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void DificuldadeUm(){
        PlayerPrefs.SetInt("Dificuldade", 1);
        SceneManager.LoadScene("Lab3");
    }
    public void DificuldadeZero(){
        PlayerPrefs.SetInt("Dificuldade", 0);
        SceneManager.LoadScene("Lab3");
    }
    public void DificuldadeDois(){
        PlayerPrefs.SetInt("Dificuldade", 2);
        SceneManager.LoadScene("Lab3");
    }
    public void DificuldadeTres(){
        PlayerPrefs.SetInt("Dificuldade", 3);
        SceneManager.LoadScene("Lab3");
    }
}
