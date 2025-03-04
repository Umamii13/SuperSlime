using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] waterball;

    private PlayerContoller playerContoller;
    private Animator anim;
    private float cooldowntimer = Mathf.Infinity;
    void Start()
    {
        anim= GetComponent<Animator>();
        playerContoller= GetComponent<PlayerContoller>();
    }

    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0) && cooldowntimer > attackcooldown && playerContoller.canAttack)
                Attack();

            cooldowntimer += Time.deltaTime;
        }
        
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldowntimer = 0;
        playerContoller.currentmana -= 10;
        if(playerContoller.currentmana < 0)
            playerContoller.currentmana= 0;
        playerContoller.Manabar.SetMana(playerContoller.currentmana);
        print(playerContoller.currentmana);

        waterball[FindWaterball()].transform.position = firepoint.position;
        waterball[FindWaterball()].GetComponent<ScrpitPJ>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindWaterball()
    {
        for(int i = 0; i < waterball.Length; i++)
        {
            if (!waterball[i].activeInHierarchy)

                return i;
 
        }
        return 0;
    }
}
