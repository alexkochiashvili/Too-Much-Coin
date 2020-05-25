using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool Paused = false;
    public GameObject PauseMenu;
    public void SetScene(int index)
    {
        Paused = false;
        SceneManager.LoadScene(index);
    }

    public void NextScene()
    {
        Paused = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    //UI
    public void ChangeTo(GameObject current, GameObject target)
    {
        current.SetActive(false);
        target.SetActive(true);
    }

    public void Pause()
    {
        Paused = !Paused;
        PauseMenu.SetActive(Paused);
    }

    void Update()
    {
        if(Paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
