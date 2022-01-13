using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class MultiplayerTable : Table
{
    public override void instantiatePlayer1Piece(int row, int column)
    {
        GameObject instantiatedObject = PhotonNetwork.Instantiate(
            player1[player1Piece].name,
            tablePieces[new Tuple<int, int>(row, column)],
            Quaternion.Euler(0f, 0f, 0f)
        );
        instantiatedObject.name = "Player 1";
    }

    public override void instantiatePlayer2Piece(int row, int column)
    {
        GameObject instantiatedObject = PhotonNetwork.Instantiate(
            player2[player2Piece].name,
            tablePieces[new Tuple<int, int>(row, column)],
            Quaternion.Euler(0f, 0f, 0f)
        );
        instantiatedObject.name = "Player 2";
    }

    public override int[,] GetTable()
    {
        //Debug.Log("Getting hashtable");

        ExitGames.Client.Photon.Hashtable tableHashtable = (ExitGames.Client.Photon.Hashtable)PhotonNetwork.CurrentRoom.CustomProperties["table"];
        
        //Debug.Log("Got hashtable");
        //Debug.Log(tableHashtable);

        int[, ] table = HashtableToTable(tableHashtable);
        //Debug.Log("Converted to table");
        return table;
    }

    public override void SetTable(int[, ] newTable)
    {
        //Debug.Log("Setting table");
        //Debug.Log(newTable);

        ExitGames.Client.Photon.Hashtable rootHashtable = new ExitGames.Client.Photon.Hashtable();
        ExitGames.Client.Photon.Hashtable tableHashtable = TableToHashtable(newTable);
        rootHashtable["table"] = tableHashtable;
        //Debug.Log("Prepared dict");
        //Debug.Log(tableHashtable);
        //Debug.Log(tableHashtable.Count);
        PhotonNetwork.CurrentRoom.SetCustomProperties(rootHashtable);
        //Debug.Log("Done Setting table");
    }

    private ExitGames.Client.Photon.Hashtable TableToHashtable(int[, ] table)
    {
        ExitGames.Client.Photon.Hashtable tableHashtable = new ExitGames.Client.Photon.Hashtable();

        for (int i = 0; i < 6; i++)
        {
            ExitGames.Client.Photon.Hashtable lineHashtable = new ExitGames.Client.Photon.Hashtable();
            for (int j = 0; j < 7; j++)
            {
                lineHashtable.Add(j.ToString(), table[i, j]);
            }
            tableHashtable.Add(i.ToString(), lineHashtable);
        }

        return tableHashtable;
    }

    private int[, ] HashtableToTable(ExitGames.Client.Photon.Hashtable tableHashtable)
    {
        int[,] table = new int[6, 7];

        for (int i = 0; i < 6; i++)
        {
            ExitGames.Client.Photon.Hashtable lineHashtable = (ExitGames.Client.Photon.Hashtable)tableHashtable[i.ToString()];
            for (int j = 0; j < 7; j++)
            {
                table[i, j] = (int)lineHashtable[j.ToString()];
            }
        }

        return table;
    }
}
