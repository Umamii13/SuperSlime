
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerContoller : MonoBehaviour
{
    public static PlayerContoller instance;
    public float Speed;
    public float jumpforce;
    public int jumpstep;
    public GameObject btnHome;
    

    public GameObject r1;
    public GameObject r2;

    public GameObject Jump1;

    public string Scene1;
    public string Scene2;
    public string Scene3;

    public GameObject Text1;
    public GameObject Text2;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Animator animchest1;
    private Animator animchest2;
    private Animator animchest3;
    private BoxCollider2D colliderCest1;
    private BoxCollider2D colliderCest2;
    private BoxCollider2D colliderCest3;

    public int maxhealth = 100;
    public int currenthealth;

    public int maxmana = 100;
    public int currentmana;
    [SerializeField]private float manareload;
    [SerializeField] private float Hpregen;
    private float reloadtimer = Mathf.Infinity;
    private float regentimer = Mathf.Infinity;


    public HPBarSlidce healthbar;
    public ManaBarslidce Manabar;
    public GameObject YouloseUi;
    public bool canAttack;
    public bool canMove;
    public bool canJump;
    public bool canCharge;

    public Health health;

    [Header("Chest")]
    public GameObject Textchest1;
    public GameObject Textchest2;
    public GameObject Textchest3;
    public GameObject chest1;
    public GameObject chest2;
    public GameObject chest3;

    public UImanager uImanager;

    [Header("///congraturation///")]
    public GameObject potalHome;
    public GameObject toHometext;
    public GameObject homeText;

    [Header("Texts")]
    public GameObject jumptext;
    public GameObject laddletext;


    [SerializeField]private bool ispower = false;

    public void Awake()
    {
        rb2d= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        animchest1 = chest1.GetComponent<Animator>();
        animchest2 = chest2.GetComponent<Animator>();
        animchest3 = chest3.GetComponent<Animator>();
        colliderCest1 = chest1.GetComponent<BoxCollider2D>();
        colliderCest2 = chest2.GetComponent<BoxCollider2D>();
        colliderCest3 = chest3.GetComponent<BoxCollider2D>();
        health = GetComponent<Health>();
        uImanager= GetComponent<UImanager>();

        currentmana = maxmana;
        Manabar.SetMaxmana(maxmana);
        
        //Disable Text
        potalHome.SetActive(false);
        homeText.SetActive(false);
        toHometext.SetActive(false);
        Textchest1.SetActive(false);
        Textchest2.SetActive(false);
        Textchest3.SetActive(false);
        jumptext.SetActive(false);
        laddletext.SetActive(false);

        health.IsDead = false;
        canAttack = true;
        canMove = true;
        canJump= true;
        canCharge = true;
    }
    public void Update()
    {
        switchScene();
        openchest();


            if(Input.GetKeyDown(KeyCode.F) && homeText.active == true)
                uImanager.Home();
            if (Input.GetKeyDown(KeyCode.F) && toHometext.active == true)
            {
                    uImanager.SetScore(); 
                    uImanager.Gamecomplete();
            }
                
            if(Input.GetKeyDown(KeyCode.F) && jumptext.active == true)
                uImanager.jumpTips();
            if(Input.GetKeyDown(KeyCode.F) && laddletext.active == true)
                uImanager.laddletips();
            

        if (uImanager.currenthero == 0)
        {
            potalHome.SetActive(true);
            ispower = true;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            uImanager.PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uImanager.Escape_tips();
        }
        if (canJump)
        {
            Jump();
        }
        if (canMove) 
        { 
            Movement(); 
        }
        if(currentmana <= 0)
        {
            currentmana = 0;
            canAttack = false;
        }
        reloadtimer += Time.deltaTime;
        regentimer+= Time.deltaTime;

        if (Input.GetKey(KeyCode.R) && reloadtimer > manareload && canCharge)
        {
            canAttack = false;
            canMove = false; 
            if (regentimer > Hpregen)
            {
                currenthealth = (int)health.currenthealth;
                currenthealth++;
                health.currenthealth = (float)currenthealth;
                healthbar.SetHealth(currenthealth);
                
                if (health.currenthealth > health.maxhealth)
                {
                    health.currenthealth = health.maxhealth;
                }
                regentimer = 0;
            }
            currentmana++;
            Manabar.SetMana(currentmana);
            if (currentmana > maxmana)
            { 
                currentmana = maxmana;
                Manabar.SetMana(currentmana);
            }
            reloadtimer = 0;

            anim.SetTrigger("charge");

            

        }
        
        if (currentmana > 0 && Input.GetKeyUp(KeyCode.R))
        {
            canAttack = true;
            canMove = true;
            anim.SetTrigger("Run");
        }
        
        
        

        if (health.IsDead == true)
        {
            currentmana = 0;
            canJump= false;
            canCharge = false;
            canAttack = false;
            canMove = false;
            Manabar.SetMana(currentmana);

            anim.SetTrigger("dead");

            GetComponent<PlayerContoller>().enabled= false;
        }//player

    }
    public void openchest()
    {
        if (Input.GetKeyDown(KeyCode.F) && Textchest1.active == true)
        {
            Textchest1.SetActive(false);
            animchest1.SetTrigger("open");
            uImanager.setchest();
            colliderCest1.enabled= false;
        }
        if (Input.GetKeyDown(KeyCode.F) && Textchest2.active == true)
        {
            Textchest2.SetActive(false);
            animchest2.SetTrigger("open");
            uImanager.setchest();
            colliderCest2.enabled= false;
        }
        if (Input.GetKeyDown(KeyCode.F) && Textchest3.active == true)
        {
            Textchest3.SetActive(false);
            uImanager.setchest();
            animchest3.SetTrigger("open");
            colliderCest3.enabled= false;
            
        }
    } //
    public void Respawn()
    {
        
        health.Awake();

        currentmana = maxmana;
        Manabar.SetMana(currentmana);

        canAttack = true;
        canMove = true;
        canJump= true;
        canCharge = true;

        anim.SetTrigger("Idle");
    } //

    
    public void switchScene()
    {
        
        if (Text1.active == true && Input.GetKeyDown(KeyCode.F))
        {
            print("1");

            SceneManager.LoadScene(Scene1,LoadSceneMode.Single);
        }

        /*if (Text2.active == true && Input.GetKeyDown(KeyCode.F))
        {
            print("2");

            SceneManager.LoadScene(Scene2, LoadSceneMode.Single);
        }*/



    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            rb2d.velocity = new Vector2(Speed, rb2d.velocity.y);
            anim.SetTrigger("Run");
            canCharge = false;
        }
        else if (Input.GetKeyUp(KeyCode.D)&& canJump)
        {
            rb2d.velocity = Vector2.zero;
            canCharge = true;
        }
            
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
            rb2d.velocity = new Vector2(-Speed, rb2d.velocity.y);
            anim.SetTrigger("Run");
            canCharge = false;
        }
        else if (Input.GetKeyUp(KeyCode.A) && canJump)
        {
            rb2d.velocity = Vector2.zero;
            canCharge = true;
        }

    }
    
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, Speed * jumpforce));
            anim.SetTrigger("Run");

            canJump = false;
            canCharge = false;
        }
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            canJump = true;
            canCharge = true;
        }

        if (collision.gameObject.tag =="Jumping" && !canJump)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, Speed * 175));
            canCharge= false;
        }
        
        
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject. tag == "Potal")
            Text1.SetActive(true);
        if (collision.gameObject.tag == "Potal2")
            Text2.SetActive(true);
        if (collision.gameObject.tag == "Chest1")
            Textchest1.SetActive(true);
        if (collision.gameObject.tag == "Chest2")
            Textchest2.SetActive(true);
        if (collision.gameObject.tag == "Chest3")
            Textchest3.SetActive(true);
        if (collision.gameObject.tag == "Finish")
            toHometext.SetActive(true);
        if (collision.gameObject.tag == "spawnpoint")
            homeText.SetActive(true);
        if(collision.gameObject.tag == "jump_tips")
            jumptext.SetActive(true);
        if(collision.gameObject.tag == "ladder_tips")
            laddletext.SetActive(true);

        if (collision.gameObject.tag == "outmap")
            uImanager.GameOver();

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "Leader")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
            canAttack = false;
        }
    }    
    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Potal")
            Text1.SetActive(false);
        if (collision.gameObject.tag == "Potal2")
            Text2.SetActive(false);
        if(collision.gameObject.tag == "Chest1")
            Textchest1.SetActive(false);
        if (collision.gameObject.tag == "Chest2")
            Textchest2.SetActive(false);
        if (collision.gameObject.tag == "Chest3")
            Textchest3.SetActive(false);
        if(collision.gameObject.tag == "Finish")
            toHometext.SetActive(false);
        if(collision.gameObject.tag == "spawnpoint")
            homeText.SetActive(false);
        if (collision.gameObject.tag == "jump_tips")
            jumptext.SetActive(false);
        if (collision.gameObject.tag == "ladder_tips")
            laddletext.SetActive(false);




        if (collision.gameObject.tag == "Leader")
        {
            canJump = true;
            canCharge= true;
            canAttack = true;
        }
    }

}
