using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{

    private int player;

    public Table tableObject;
    private int[,] table;

    public AI AI;

    // Start is called before the first frame update
    void Start()
    {
        this.player = 0;
        table = tableObject.GetTable();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player: " + this.player);
    }

    public void SetPlayer(int player)
    {
        this.player = player % 2;
    }

    public int GetPlayer()
    {
        return this.player;
    }

    virtual public void MoveMade(int column)
    {
        if (tableObject.CheckIfMoveIsPossible(column))
        {
            
            tableObject.MovePiece(column, this.player);
            if (HasGameEnded(table, 1))
            {
                Debug.Log("Player 1 Won !!!");
            }
            
            //AI
            Debug.Log("AI moves: " + AI.AIMove());
            tableObject.MovePiece(AI.AIMove(), 1);
            if (HasGameEnded(table, 2))
            {
                Debug.Log("Player 2 Won !!!");
            }
            

        }
    }


    private bool CheckFinishedOnRows(int [, ] table, int player)
    {
        for (int j = 0; j < 4; j++)
            for (int i = 0; i < 6; i++)
                if (table[i, j] == player && table[i, j + 1] == player && table[i, j + 2] == player && table[i, j + 3] == player)
                    return true;

        return false;
    }

    private bool CheckFinishedOnColumns(int[,] table, int player)
    {
        for (int j = 0; j < 7; j++)
            for (int i = 0; i < 3; i++)
                if (table[i, j] == player && table[i + 1, j] == player && table[i + 2, j] == player && table[i + 3, j] == player)
                    return true;

        return false;
    }

    private bool CheckFinishedOnDiaganols(int[,] table, int player)
    {
        //positively sloped diaganols
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
                if (table[i, j] == player && table[i 
                    + 1, j + 1] == player && table[i + 2, j + 2] == player && table[i + 3, j + 3] == player)
                    return true;

        for (int i = 0; i < 3; i++)
            for (int j = 3; j < 7; j++)
                if (table[i, j] == player && table[i
                    + 1, j - 1] == player && table[i + 2, j - 2] == player && table[i + 3, j - 3] == player)
                    return true;
        
        return false;
    }

    public bool HasGameEnded(int[, ] table, int player)
    {
        if (CheckFinishedOnRows(table, player) || CheckFinishedOnColumns(table, player) || CheckFinishedOnDiaganols(table, player))
            return true;

        return false;
    }

}
