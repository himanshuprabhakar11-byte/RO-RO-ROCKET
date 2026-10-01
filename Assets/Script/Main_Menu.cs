using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Main_Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); 

    }

    public void QuitGame()
    {
        Application.Quit();

         Debug.Log("Done");
    }




}
