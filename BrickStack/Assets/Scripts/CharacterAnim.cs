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
        if (transform.hasChanged)
        {
            Anim.SetBool("IsRunning", true);
        }
        else
        {
            Anim.SetBool("IsRunning", false);
        }
    }
}
