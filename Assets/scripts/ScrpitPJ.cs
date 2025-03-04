using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrpitPJ : MonoBehaviour

{
    public static ScrpitPJ instance;

    [SerializeField] private float ballspeed;
    private float direction;
    private bool hit;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim= GetComponent<Animator>();
        boxCollider= GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (hit) return;
        float movespeed = ballspeed * Time.deltaTime * direction;

        transform.Translate(movespeed, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("expold");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<EnemyHP>().Takedamage(10);
        }
            

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("expold");

    }


    public void setDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localscaleX = transform.localScale.x;
        if(Mathf.Sign(localscaleX) != _direction)
            localscaleX =-localscaleX;

        transform.localScale = new Vector3(localscaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
