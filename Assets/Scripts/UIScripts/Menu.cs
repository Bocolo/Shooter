using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
      
        SceneManager.LoadScene(1);

    }
    public void ReturnToIntro()
    {
        SceneManager.LoadScene(0);
    }
}
