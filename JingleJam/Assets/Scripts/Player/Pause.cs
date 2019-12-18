using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused = false;
    private GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = togglePause();
        }
           
    }

    bool togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            return (true);
        }
    }

    public void Resume()
    {
        paused = togglePause();

    }

    public void Restart()
    {
        paused = togglePause();
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void BackToMenu()
    {
        paused = togglePause();
        SceneManager.LoadScene(0);
    }
}
