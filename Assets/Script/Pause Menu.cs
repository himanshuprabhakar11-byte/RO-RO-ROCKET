using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //[SerializeField] GameObject pauseMenu;

    //public void pause ()
    //{
    //    pauseMenu.SetActive(true);
    //}
    public void Home ()
    {
        SceneManager.LoadScene("Main Menu");
    }
    //public void Resume ()
    //{
    //    pauseMenu.SetActive(false);
    //}
    //public void Restart ()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}
}
