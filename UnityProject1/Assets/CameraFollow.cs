using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float followSpeed;
    public float rotationSpeed;
    public Vector3 cameraOffset = new Vector3(0.0f, 0.0f, 0.0f);

    //Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(target.transform.forward);
        transform.position = CalculateCameraTargetPosition();
    }

    Vector3 CalculateCameraTargetPosition()
    {
        Vector3 cameraPosition = target.transform.position;

        cameraPosition = cameraPosition + (target.transform.forward * cameraOffset.z);
        cameraPosition = cameraPosition + (target.transform.up * cameraOffset.y);
        cameraPosition = cameraPosition + (target.transform.right * cameraOffset.x);

        return cameraPosition;
    }
    
    //Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = CalculateCameraTargetPosition();

        transform.position = Vector3.Slerp(transform.position, 
            targetPosition, followSpeed);

        float rotationStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target.transform.forward, 
            rotationStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}