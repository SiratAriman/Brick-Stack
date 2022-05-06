using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    private Transform Player;
    [SerializeField] private float RotationSpeed;

    private void Start()
    {
        Player = transform;
    }

    public void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 MovementDirection = new Vector3(horizontalInput, 0, verticalInput);
        MovementDirection.Normalize();
        transform.Translate(MovementDirection * MoveSpeed * Time.deltaTime, Space.World);
        
        if (MovementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(MovementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, RotationSpeed *Time.deltaTime);
        }
    }
}
    