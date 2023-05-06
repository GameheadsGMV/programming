using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int myInt; 
    public float speed = 1.0f;
    public float jumpStrength = 10.0f;
    public float rotationSpeed = 5.0f;

    private Rigidbody rb;
    private Vector2 lastMousePosition = new Vector2(0.0f, 0.0f);
 
    // Start is called before the first frame update
    void Start()
    {
        myInt = 0;

        rb = gameObject.GetComponent<Rigidbody>();

        lastMousePosition = Input.mousePosition;
    }

    void RotateCamera()
    {
        Vector2 currentMousePosition = Input.mousePosition;
        Vector2 mouseDistance = currentMousePosition - lastMousePosition;

        Vector3 cameraRotation = new Vector3(0.0f, rotationSpeed * mouseDistance.x * Time.deltaTime, 0.0f);
        transform.Rotate(cameraRotation);    

        lastMousePosition = currentMousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        Vector3 movDir = new Vector3(0.0f, 0.0f, 0.0f);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            movDir = transform.forward;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movDir = -transform.forward;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            movDir = -transform.right;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))    
        {
            movDir = transform.right;
        }       

        gameObject.transform.Translate(speed * movDir * Time.deltaTime);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3 jumpForce = new Vector3(0.0f, jumpStrength, 0.0f);
            
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }
}