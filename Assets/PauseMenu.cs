using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //scene manager so we can change scenes 

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu; //serialized field so we can assign the pause menu in the inspector
    public GameObject PausePanel;

    // Update is called once per frame
    public void Pause() //activate the pause menu and set time scale to 0 so the game is paused
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue() // hides pause menu and resumes game time
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home() //loads the main menu scene 
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1; //lets player play game after choosing a level from the main menu
    }

    public void Restart() //reloads current scene 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
