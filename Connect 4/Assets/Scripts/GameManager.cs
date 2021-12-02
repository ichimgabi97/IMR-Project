using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int player;

    public Table tableObject;
    private int[,] table;

    // Start is called before the first frame update
    void Start()
    {
        this.player = 0;
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
}
