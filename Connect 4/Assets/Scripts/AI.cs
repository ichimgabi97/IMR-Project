using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public GameManager gameManager;
    private int[,] tableAI;

    public Table tableObject;
    private int[,] tableGame;

    // Start is called before the first frame update
    void Start()
    {
        this.tableAI = new int[6, 7];
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                this.tableAI[i, j] = 0;
            }
        }
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
                if (j < 6)
                {
                    result = result + table[i, j] + " ";
                }
                else
                {
                    result = result + table[i, j];
                }

            }
            if (i < 5)
            {
                result = result + '\n';
            }
        }

        Debug.Log(result);
    }

    private void MakeACopy(int [,] table)
    {

        TableView(this.tableAI);
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                this.tableAI[i, j] = table[i, j];
            }
        }
    }

    private bool CheckIfMoveIsPossible(int column, int [,] table)
    {
        for (int i = 5; i >= 0; i--)
            if (table[i, column] == 0)
            {
                return true;
            }

        return false;
    }

    private int [, ] SimulateMove(int column, int[,] table)
    {
        if (CheckIfMoveIsPossible(column, table))
        {
            for (int i = 5; i >= 0; i--)
                if (table[i, column] == 0)
                {
                    table[i, column] = 2;
                    break;
                }
        }

        return table;
    }


    //ToDo
    public int Evaluation(int position, int[,] table)
    {
        int result = Random.Range(0, 30);

        return result;
    }

    private int MaxTwoNumbers(int a, int b)
    {
        if(a < b)
        {
            return b;
        }
        else
        {
            return a;
        }
    }

    private int MinTwoNumbers(int a, int b)
    {
        if(a <= b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    public int Minimax( int position, int[, ] table, int depth, bool maximizingPlayer = true, int alpha = -999999, int beta = 999999)
    {
        if (depth == 0 || gameManager.HasGameEnded(SimulateMove(position, table), 2))
        {
            return Evaluation(position, table);
        }

        if (maximizingPlayer)
        {
            int maxEval = -999999;
            for(int i = 0; i < 7; i++)
            {
                int eval = Minimax(i, table, depth - 1, false, alpha, beta);
                maxEval = MaxTwoNumbers(maxEval, eval);
                alpha = MaxTwoNumbers(alpha, eval);
                if(beta <= alpha)
                {
                    break;
                }
            }
            return maxEval;
        }
        else
        {
            int minEval = 999999;
            for (int i = 0; i < 7; i++)
            {
                int eval = Minimax(i, table, depth - 1, true, alpha, beta);
                minEval = MinTwoNumbers(minEval, eval);
                beta = MinTwoNumbers(beta, eval);
                if(beta <= alpha)
                {
                    break;
                }
            }
            return minEval;
        }
    }

    public int AIMove()
    {
        int bestMove = 12;
        int bestMoveEvaluation = -999999;
        for(int i = 0; i < 7; i++)
        {
            MakeACopy(tableObject.GetTable());
            if (bestMoveEvaluation < Minimax(i, this.tableAI, 3))
            {
                bestMoveEvaluation = Minimax(i, this.tableAI, 3);
                bestMove = i;
            }
               
        }

        return bestMove;
    }

}
