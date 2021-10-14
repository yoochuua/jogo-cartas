using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerCreditos : MonoBehaviour
{
    // Start is called before the first frame update
    /*volta para a cena do menu principal*/
  public void voltarMenu (){
      SceneManager.LoadScene("Menu");
  }
}
