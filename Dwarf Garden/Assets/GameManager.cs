using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string matchScene = "Match";
    public string menuScene = "Menu";

    public GameManager Instance;

    void Awake() {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void EnterMatch() {
        SceneManager.LoadScene(matchScene);
    }

    public void EnterMenu() {
        SceneManager.LoadScene(menuScene);
    }

    public void CloseApplication() {
        Application.Quit();
    }
}
