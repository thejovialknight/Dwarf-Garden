using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public int currentPlayer;
    public List<PlayerController> players = new List<PlayerController>();

    public static MatchManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public PlayerController CurrentPlayer() {
        return players[currentPlayer];
    }

    public void StartMatch() {
        currentPlayer = -1;
        AdvanceTurn();
    }

    public void AdvanceTurn() {
        if(currentPlayer > -1 && players[currentPlayer]!= null) {
            players[currentPlayer].EndTurn();
        }

        currentPlayer++;
        if(currentPlayer >= players.Count) {
            currentPlayer = 0;
        }

        players[currentPlayer].StartTurn();
    }
}
