using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static Health instance;
    private UImanager uImanager;
    [Header("Health")]
    public float maxhealth;
    public float currenthealth; //{ get; private set; }
    private Animator anim;
    public bool IsDead;
    public HPBarSlidce healthbar;

    [Header("iFrame")]
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberofFlashes;
    private SpriteRenderer spriteRend;
    private PlayerRespawn respawn;


    public void Awake()
    {
        currenthealth = maxhealth;        
        healthbar.SetMaxHealth((int)maxhealth);
        respawn= gameObject.GetComponent<PlayerRespawn>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        IsDead = false;
        uImanager = GetComponent<UImanager>();

    }

    public void Takedamage(int _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, maxhealth);
        healthbar.SetHealth((int)currenthealth);

        if (currenthealth> 0)
        {
            anim.SetTrigger("Hurt");
            //iFrame code **
        }
        else
        {
            if (!IsDead)
            {
                anim.SetTrigger("dead");
                respawn.canrespawn = true;
                uImanager.GameOver();
                IsDead=true;
            }
            if (Input.GetKeyDown(KeyCode.R) && currenthealth <=0)
            {
                anim.SetTrigger("dead");
                uImanager.GameOver();
                respawn.canrespawn = true;
                IsDead = true;

            }
        }
    }
}
