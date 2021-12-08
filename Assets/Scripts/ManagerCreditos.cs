using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///<summary>
/// Classe que controla as funcoes da scene "Creditos"
///</summary>
public class ManagerCreditos : MonoBehaviour
{
  /*
    Volta para a cena do menu principal
  */
  public void voltarMenu (){
      SceneManager.LoadScene("Menu");
  }
}
