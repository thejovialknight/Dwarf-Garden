using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameData save;
    public GameState state = GameState.Init;

    public string matchScene = "Match";
    public string menuScene = "Menu";

    public static GameManager Instance;

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

        if(File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            DeserializeGameData();
        }
        else
        {
            save = new GameData();
            SerializeGameData();
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(state == GameState.Match)
        {
            TileManager.Instance.SetupMatch();
        }

        if(state == GameState.Init)
        {
            EnterMenu();
        }
    }

    void SerializeGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.Create);

        bf.Serialize(stream, save);
        stream.Close();
    }

    void DeserializeGameData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/save.dat", FileMode.Open);

        save = bf.Deserialize(stream) as GameData;
        stream.Close();
    }

    #region Scene Management

    public void EnterMatch() {
        state = GameState.Match;
        SceneManager.LoadScene(matchScene);
    }

    public void EnterMenu() {
        state = GameState.Menu;
        SceneManager.LoadScene(menuScene);
    }

    public void CloseApplication() {
        Application.Quit();
    }

    #endregion
}

public enum GameState
{
    Init,
    Menu,
    Match
}

[System.Serializable]
public class GameData
{
    // data variables

    public GameData()
    {

    }
}
