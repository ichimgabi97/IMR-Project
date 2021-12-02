using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    private int[ , ] table;
    private Dictionary<Tuple<int, int>, Vector3> tablePieces;
    public GameObject player1;
    public GameObject player2;


    // Start is called before the first frame update
    void Start()
    {
        tablePieces = new Dictionary<Tuple<int, int>, Vector3>();

        this.table = new int[6, 7];

        float y = 8f;
        for (int i = 0; i < 6; i++)
        {
            float x = 0f;
            for (int j = 0; j < 7; j++)
            {
                this.table[i, j] = 0;
                tablePieces.Add(new Tuple<int, int>(i, j), new Vector3(x, y, 0));
                x += 1.5f;
            }
            y -= 1.5f;
        }
            
        Debug.Log("POsition of piece: " + tablePieces[new Tuple<int, int>(3, 0)]);

    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void MovePiece(int column, int player)
    {
        if (CheckIfMoveIsPossible(column))
        {
            for (int i = 5; i >= 0; i--)
                if (table[i, column] == 0)
                {
                    table[i, column] = player + 1;
                    //TableView(table);
                    if(player == 0)
                    {
                        GameObject instantiatedObject = Instantiate(player1, tablePieces[new Tuple<int, int>(i, column)], Quaternion.Euler(0f, 0f, 0f));
                        instantiatedObject.name = "Player 1";
                    }
                    else
                    {
                        GameObject instantiatedObject = Instantiate(player2, tablePieces[new Tuple<int, int>(i, column)], Quaternion.Euler(0f, 0f, 0f));
                        instantiatedObject.name = "Player 2";
                    }
                    break;
                }
        }else
        {
            Debug.Log("col Full: " + column);
        }
    }

    public bool CheckIfMoveIsPossible(int column)
    {
        for (int i = 5; i >= 0; i--)
            if(table[i, column] == 0)
            {
                return true;
            }
        
        return false;
    }

    public int[,] GetTable()
    {
        return table;
    }
}
