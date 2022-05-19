using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    public static Animator Anim;
    private Transform Player;
    private void Start()
    {
        Anim = GetComponent<Animator>();
        Player = transform;
    }
    private void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 MovementDirection = new Vector3(horizontalInput, 0, verticalInput);
        
        if (MovementDirection != Vector3.zero)
        {
            Anim.SetBool("IsRunning", true);
        }
        else
        {
            Anim.SetBool("IsRunning", false);
        }
    }
}
