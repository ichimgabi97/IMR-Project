using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    protected int[ , ] table;
    protected Dictionary<Tuple<int, int>, Vector3> tablePieces;
    public List<GameObject> player1;
    public int player1Piece;
    public List<GameObject> player2;
    public int player2Piece;

    // Start is called before the first frame update
    void Start()
    {
        tablePieces = new Dictionary<Tuple<int, int>, Vector3>();

        int[,] table = new int[6, 7];

        float y = 8f;
        for (int i = 0; i < 6; i++)
        {
            float x = -4f;
            for (int j = 0; j < 7; j++)
            {
                table[i, j] = 0;
                tablePieces.Add(new Tuple<int, int>(i, j), new Vector3(x, y, 4));
                x += 1.46f;
            }
            y -= 1.5f;
        }
        Debug.Log("Table is");
        Debug.Log(table);
        SetTable(table);
            
        Debug.Log("POsition of piece: " + tablePieces[new Tuple<int, int>(3, 0)]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual public int[, ] GetTable()
    {
        return table;
    }

    virtual public void SetTable(int[,] newTable)
    {
        table = newTable;
    }

    private void TableView(int[,] table)
    {
        string result = "";
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if ( j < 6)
                {
                    result = result + table[i, j] + " ";
                }else
                {
                    result = result + table[i, j];
                }
                
            }
            if(i < 5)
            {
                result = result + '\n';
            }
        }

        Debug.Log(result);
    }

    virtual public void MovePiece(int column, int player)
    {
        if (CheckIfMoveIsPossible(column))
        {
            for (int i = 5; i >= 0; i--)
            {
                int[,] table = GetTable();
                if (table[i, column] == 0)
                {

                    table[i, column] = player + 1;
                    SetTable(table);
                    //TableView(table);
                    if (player == 0)
                    {
                        instantiatePlayer1Piece(i, column);
                    }
                    else
                    {
                        instantiatePlayer2Piece(i, column);
                    }
                    break;
                }
            }
        }else
        {
            Debug.Log("col Full: " + column);
        }
    }

    virtual public void instantiatePlayer1Piece(int row, int column)
    {    
        GameObject instantiatedObject = Instantiate(player1[player1Piece], tablePieces[new Tuple<int, int>(row, column)], Quaternion.Euler(0f, 0f, 0f));
        instantiatedObject.name = "Player 1";
    }


    virtual public void instantiatePlayer2Piece(int row, int column) 
    { 
        GameObject instantiatedObject = Instantiate(player2[player2Piece], tablePieces[new Tuple<int, int>(row, column)], Quaternion.Euler(0f, 0f, 0f));
        instantiatedObject.name = "Player 2";
    }


    public bool CheckIfMoveIsPossible(int column)
    {
        for (int i = 5; i >= 0; i--)
            if(GetTable()[i, column] == 0)
            {
                return true;
            }
        
        return false;
    }
}
