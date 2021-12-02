using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectedColumn : MonoBehaviour
{

    public UnityEvent unityEvent = new UnityEvent();
    private GameObject button;

    public InputColumn test;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            unityEvent.Invoke();
        }
    }



    public void OnClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(this.gameObject.name);
            //int colNumber = System.Int32.Parse(new string(this.gameObject.name[this.gameObject.name.Length - 1], 1));
            test.ColumnClicked(this.gameObject);
            //Debug.Log("col: " + colNumber);
        }
    }
}
