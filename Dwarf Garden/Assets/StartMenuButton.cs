using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuButton : MonoBehaviour
{
    void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(StartMatch);
    }

    void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(StartMatch);
    }

    void StartMatch()
    {
        GameManager.Instance.EnterMatch();
    }
}
