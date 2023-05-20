using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject target;

    public float spawnTime = 0.0f;
    public float bulletForce = 3.0f;
    public float targetSpeed = 1.0f;

    private float currentTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= spawnTime)
        {
            //Spawn a bullet
            Vector3 spawnPosition = transform.position + transform.forward * 0.9f;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);

            currentTime = 0.0f;
        }    

        Vector3 targetDirection = target.transform.position - transform.position;

        float rorationStep = targetSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, 
        targetSpeed, 0.0f);    
        transform.rotation = Quaternion.LookRotation(newDirection);

    }
}
