using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistant;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask Playerlayer;
    private float cooldowntimer = Mathf.Infinity;

    private Animator animator;
    private Health playerhealth;

    private EnemyPratro enemyPratro;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerhealth = GetComponent<Health>();
        enemyPratro = GetComponentInParent<EnemyPratro>();
    }

    void Update()
    {
        cooldowntimer += Time.deltaTime;
       
        if (playerinside())
        {
            if(cooldowntimer >= attackcooldown)
            {
                cooldowntimer = 0;
                animator.SetTrigger("meleeatack");
            }
        }
        if(enemyPratro!= null)
        {
            enemyPratro.enabled = !playerinside();
        }
    }
    private bool playerinside()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant, 
            new Vector3(boxCollider.bounds.size.x * range ,boxCollider.bounds.size.y , boxCollider.bounds.size.z), 
            0, Vector2.left, 0, Playerlayer);
        if (hit.collider != null)
            playerhealth= hit.transform.GetComponent<Health>();
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistant,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
    private void DamagePlayer()
    {
        if (playerinside())
        {
            playerhealth.Takedamage(damage);
        }
    }
}
