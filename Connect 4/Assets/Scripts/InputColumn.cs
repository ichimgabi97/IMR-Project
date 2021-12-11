using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputColumn : MonoBehaviour
{

    public Table table;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColumnClicked(GameObject column)
    {
        int colNumber = System.Int32.Parse(new string(column.name[column.name.Length - 1], 1));
        //Debug.Log(column);
        gameManager.MoveMade(colNumber);       
    }
}
