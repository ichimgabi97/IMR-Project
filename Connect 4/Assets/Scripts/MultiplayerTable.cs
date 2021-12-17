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
}
