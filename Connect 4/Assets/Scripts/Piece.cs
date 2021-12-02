using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public GameObject piece;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void SetPosition(Vector3 position)
    {
        this.gameObject.transform.position = position - new Vector3(0,9,0);
    }

    public Vector3 GetPosition()
    {
        return this.gameObject.transform.position;
    }
}
