using UnityEngine;

public class EnemyPratro : MonoBehaviour
{
    [Header("Patro point")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("MoveMent Paramiter")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool MovingLeft;

    [Header("IdleTime")]
    [SerializeField] private float idleduration;
    private float idletimer;

    [Header("Animator Enemy")]
    [SerializeField]private Animator anim;

    private void Awake()
    {
        initscale = enemy.localScale;
    }

    private void Update()
    {
        if (MovingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                moveIndirection(-1);
            else
            {
                Directionchange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                moveIndirection(1);
            else
            {
                Directionchange();
            }
        }
        
    }

    private void OnDisable()
    {
        anim.SetBool("moving", false);
    }
    private void Directionchange()
    {
        anim.SetBool("moving", false);
        idletimer += Time.deltaTime;

        if(idletimer > idleduration)
            MovingLeft = !MovingLeft;
    }
    private void moveIndirection(int _duration)
    {
        idletimer = 0;
        anim.SetBool("moving", true);
        
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _duration, initscale.y, initscale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _duration * speed,
            enemy.position.y, enemy.position.z);
    }
}
