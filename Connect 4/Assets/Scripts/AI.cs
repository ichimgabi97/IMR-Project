using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Evaluation(int position, int[, ] table)
    {
        int result = 0;

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

    public int minimax( int position, int[, ] table, int depth, bool maximizingPlayer, int alpha = -999999, int beta = 999999)
    {
        if (depth == 0 /*|| GameEnded()*/ )
        {
            return Evaluation(position, table);
        }

        if (maximizingPlayer)
        {
            int maxEval = -999999;
            for(int i = 0; i < 7; i++)
            {
                int eval = minimax(i, table, depth - 1, false, alpha, beta);
                maxEval = MinTwoNumbers(maxEval, eval);
                alpha = MinTwoNumbers(alpha, eval);
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
                int eval = minimax(i, table, depth - 1, true, alpha, beta);
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

}
