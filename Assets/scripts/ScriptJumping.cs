using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptJumping : MonoBehaviour
{
    public static ScriptJumping instance;

    private Animator Anim;
    private void Awake()
    {
        Anim= GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Anim.SetTrigger("Jump");  
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Anim.SetTrigger("Idle");
    }
}
