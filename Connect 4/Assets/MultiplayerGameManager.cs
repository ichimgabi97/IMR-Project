using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerGameManager : GameManager
{

    int currentPlayer = 0;
    
    int[] players = new int[2];
    int numberOfPlayers = 0;

    public void Awake()
    {
        int myId = PhotonNetwork.LocalPlayer.ActorNumber;

        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            int id = playerInfo.Value.ActorNumber;
            if (numberOfPlayers < 2 && myId != id)
            {
                players[numberOfPlayers] = id;
                numberOfPlayers++;
            }
        }

        if (numberOfPlayers < 2)
        {
            players[numberOfPlayers] = myId;
            numberOfPlayers++;
        }

        ResetCurrentPlayer();
    }

    private void ResetCurrentPlayer()
    {
        currentPlayer = (int)(Random.Range(0f, 1f) * numberOfPlayers);
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.Log("Appeared player:" + player.ActorNumber);

        if (numberOfPlayers < 2)
        {
            players[numberOfPlayers] = player.ActorNumber;
            numberOfPlayers++;

            ResetCurrentPlayer();
        }
    }

    public bool IsMyTurn()
    {
        return players[currentPlayer] == PhotonNetwork.LocalPlayer.ActorNumber;
    }

    public bool HasGameEndedForAnyPlayer(int[,] table)
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            if (HasGameEnded(table, i + 1))
            {
                Debug.Log("Ended for " + i);
                return true;
            }
        }
        return false;
    }

    public override void MoveMade(int column)
    {
        Debug.Log("Players: " + players[0] + players[1]);
        Debug.Log("Current player:" + currentPlayer);
        Debug.Log(!HasGameEndedForAnyPlayer(tableObject.GetTable()));
        Debug.Log(IsMyTurn());
        Debug.Log(tableObject.CheckIfMoveIsPossible(column));
        if (!HasGameEndedForAnyPlayer(tableObject.GetTable()) && IsMyTurn() && tableObject.CheckIfMoveIsPossible(column))
        {
            Debug.Log("Placing Piece");
            tableObject.MovePiece(column, currentPlayer);
            currentPlayer = (currentPlayer + 1) % 2;
        }
    }
}
