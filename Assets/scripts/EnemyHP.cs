using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public GameObject slotenemy;
    public ScriptEnemySummon enemy;

    public GameObject UI;
    private UImanager manager;

    public static EnemyHP Instance;
    [Header("Health")]
    public float maxhealth;
    public float currenthealth;
    private Animator anim;
    public bool IsDead;
    public HPBarSlidce healthbar;

    [Header("Deative Enemy")]
    [SerializeField] float destroytime;
    private float cooldowntimer = Mathf.Infinity;
    [SerializeField]private GameObject Enemy;
    [SerializeField] private GameObject HPbar;
    
    /*[Header("traget")]
    [SerializeField] private TextMeshProUGUI targethero;
    public float currenthero;
    [SerializeField]private float Targethero;*/
    public void Awake()
    {
        //targethero.text = currenthero + " / " + Targethero;
        currenthealth = maxhealth;
        healthbar.SetMaxHealth((int)maxhealth);
        anim = GetComponent<Animator>();
        //currenthero = Targethero;
        enemy = slotenemy.GetComponent<ScriptEnemySummon>();
        manager = UI.GetComponent<UImanager>();


    }
    private void Update()
    {
        if (IsDead)
        {
            HPbar.SetActive(false);
            
            if(cooldowntimer > destroytime)
                Enemy.gameObject.SetActive(false);
            //print(currenthero);
            
        }
        cooldowntimer += Time.deltaTime;
    }
    public void Takedamage(int _damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - _damage, 0, maxhealth);
        
        healthbar.SetHealth((int)currenthealth);

        if (currenthealth > 0)
        {
            anim.SetTrigger("hurt");
            //iFrame code **
        }
        else
        {
            if (!IsDead)
            {
                anim.SetTrigger("die");

                if(GetComponentInParent<EnemyPratro>() != null)
                {
                    GetComponentInParent<EnemyPratro>().enabled = false;
                }
                if(GetComponent<EnemyMelee>() != null)
                {
                    GetComponent<EnemyMelee>().enabled = false;
                }
                cooldowntimer = 0;
                manager.SetEnemy();
                IsDead=true;

            }
            
        }
    }
}
