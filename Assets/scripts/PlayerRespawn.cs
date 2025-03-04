using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static PlayerRespawn instance;
    public PlayerContoller Playercontoller;
    public Health health;
    public Animator anim;
    public bool canrespawn = false;
    void Start()
    {
        Playercontoller= GetComponent<PlayerContoller>();
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (health.IsDead == true && Input.GetKeyDown(KeyCode.P) && canrespawn == true)
        {
            Playercontoller.enabled = true;
            Playercontoller.Respawn();
            health.IsDead = false;
            canrespawn= false;
        }

    }
}
