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

        //TableView(this.tableAI);
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

    private int [, ] SimulateMove(int column, int[,] table, bool isAITurn)
    {
        if (CheckIfMoveIsPossible(column, table))
        {
            for (int i = 5; i >= 0; i--)
                if (table[i, column] == 0)
                {
                    if (isAITurn)
                    {
                        table[i, column] = 2;
                        break;
                    }
                    else
                    {
                        table[i, column] = 1;
                        break;
                    }
                    
                }
        }

        return table;
    }


    //ToDo
    public int Evaluation(int[,] table)
    {
        int score = 0;

        //Rows
        for (int j = 0; j < 4; j++)
            for (int i = 0; i < 6; i++)
            {
                int player = 0;
                int ai = 0;
                int offset = 3;

                //check 4 positions to see the number of apparition of player and ai
                while (offset >= 0)
                {
                    if(table[i, j + offset] == 1)
                    {
                        player += 1;
                    }
                    else if(table[i, j + offset] == 2)
                    {
                        ai += 1;
                    }

                    offset -= 1;
                }

                //score for winning move 
                if (player == 4 && ai == 0)
                {
                    score -= 900;
                }
                else if(player == 0 && ai == 4)
                {
                    score += 900;
                }

                //score for 3 inline
                if(player == 3 && ai == 0)
                {
                    score -= 10;
                }
                else if(player == 0 && ai == 3)
                {
                    score += 10;
                }
            }

        //Columns
        for (int j = 0; j < 7; j++)
            for (int i = 0; i < 3; i++)
            {
                int player = 0;
                int ai = 0;
                int offset = 3;

                //check 4 positions to see the number of apparition of player and ai
                while (offset >= 0)
                {
                    if (table[i + offset, j] == 1)
                    {
                        player += 1;
                    }
                    else if (table[i + offset, j] == 2)
                    {
                        ai += 1;
                    }

                    offset -= 1;
                }

                //score for winning move 
                if (player == 4 && ai == 0)
                {
                    score -= 900;
                }
                else if (player == 0 && ai == 4)
                {
                    score += 900;
                }

                //score for 3 inline
                if (player == 3 && ai == 0)
                {
                    score -= 10;
                }
                else if (player == 0 && ai == 3)
                {
                    score += 10;
                }
            }

        //diagonal 1
         for (int i = 0; i < 3; i++)
            for (int j = 0; j < 4; j++)
            {
                int player = 0;
                int ai = 0;
                int offset = 3;

                //check 4 positions to see the number of apparition of player and ai
                while (offset >= 0)
                {
                    if (table[i + offset, j + offset] == 1)
                    {
                        player += 1;
                    }
                    else if (table[i + offset, j + offset] == 2)
                    {
                        ai += 1;
                    }

                    offset -= 1;
                }

                //score for winning move 
                if (player == 4 && ai == 0)
                {
                    score -= 900;
                }
                else if (player == 0 && ai == 4)
                {
                    score += 900;
                }

                //score for 3 inline
                if (player == 3 && ai == 0)
                {
                    score -= 10;
                }
                else if (player == 0 && ai == 3)
                {
                    score += 10;
                }
            }

        //diagonal 2
        for (int i = 0; i < 3; i++)
            for (int j = 3; j < 7; j++)
            {
                int player = 0;
                int ai = 0;
                int offset = 3;

                //check 4 positions to see the number of apparition of player and ai
                while (offset >= 0)
                {
                    if (table[i + offset, j - offset] == 1)
                    {
                        player += 1;
                    }
                    else if (table[i + offset, j - offset] == 2)
                    {
                        ai += 1;
                    }

                    offset -= 1;
                }

                //score for winning move 
                if (player == 4 && ai == 0)
                {
                    score -= 900;
                }
                else if (player == 0 && ai == 4)
                {
                    score += 900;
                }

                //score for 3 inline
                if (player == 3 && ai == 0)
                {
                    score -= 10;
                }
                else if (player == 0 && ai == 3)
                {
                    score += 10;
                }
            }
        
        return score;
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
        int[,] tablePos = SimulateMove(position, table, maximizingPlayer);

        if (depth == 0 || gameManager.HasGameEnded(tablePos, maximizingPlayer ? 2 : 1))
        {
            return Evaluation(tablePos);
        }

        if (maximizingPlayer)
        {
            int maxEval = -999999;
            for(int i = 0; i < 7; i++)
            {
                int eval = Minimax(i, tablePos, depth - 1, false, alpha, beta);
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
                int eval = Minimax(i, tablePos, depth - 1, true, alpha, beta);
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
        int errorAI = 0;
        do
        {
            errorAI += 1;
            bestMove = 12;
            int bestMoveEvaluation = -999999;
            for (int i = 0; i < 7; i++)
            {
                MakeACopy(tableObject.GetTable());

                int result = Minimax(i, this.tableAI, 15);

                if (bestMoveEvaluation < result)
                {
                    bestMoveEvaluation = result;
                    bestMove = i;
                }

            }

            if(errorAI > 6)
            {
                Debug.Log("AI error");
                break;
            }

        } while (!CheckIfMoveIsPossible(bestMove, tableObject.GetTable()));
        return bestMove;
    }

}
