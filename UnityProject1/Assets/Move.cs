using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int myInt; 
 
    // Start is called before the first frame update
    void Start()
    {
        myInt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        myInt = myInt + 1;
        Debug.Log(myInt);

        gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
    }
}
