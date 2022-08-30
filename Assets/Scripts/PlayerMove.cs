using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    int speed, rotationSpeed;

    [SerializeField]
    SpawnEnemy Spawner;

    float vertInput, horInput;

    Rigidbody selfRigidBody;

    private void Start()
    {
        selfRigidBody = GetComponent<Rigidbody>();
        Spawner = FindObjectOfType<SpawnEnemy>();
    }

    private void Update()
    {
        vertInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * (vertInput * speed * Time.deltaTime);
        selfRigidBody.MovePosition(selfRigidBody.position + movement);
    }

    private void Rotate()
    {
        float rotate = horInput * rotationSpeed * Time.deltaTime;
        Quaternion rotateAngle = Quaternion.Euler(0, rotate, 0);
        selfRigidBody.MoveRotation(selfRigidBody.rotation * rotateAngle);
    }

    private void OnDestroy()
    {
        if (Spawner != null)
        {
            Spawner.PlayerDead();
        }
    }
}
