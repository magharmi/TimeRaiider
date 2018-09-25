using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler_Controller : MonoBehaviour {
    //InventarSystem
    //public GameObject fakel, stoneAgeKnife;
    // Inventory inventory;
    //Leben und Skill
    
    //Spieler bewegung
    public float maxGeschwindigkeit;
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeigth;

    //fuer armbrust
    public Transform schussPos;
    public GameObject pfeil;
    public float schussRate = 0.5f;
    float nextSchuss = 0f;

    //facing variable
    bool facingRight;

    //Verknüpfung zu Rigidbody und animator
    Rigidbody2D myRb;
    Animator myAnim;


    void Awake()
    {
     
    }
    // Use this for initialization
    void Start() {

        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        //gesicht nach rechts
        facingRight = true;
    }
    
    /*
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("enemy"))
        {
            
            Destroy(gameObject);
            SoundManagerScript.PlaySound("BlutPlatzt");
            SoundManagerScript.PlaySound("Blut1");
        }
    }
    */
    
    void Update()
    {

        //Spieler Speer Angriff
        if (Input.GetKeyDown(KeyCode.T))
        {
            myAnim.SetBool("isAttack", true);

        }
        else {
            myAnim.SetBool("isAttack", false);
        }
        //Spieler Stein Angriff
        if (Input.GetKeyDown(KeyCode.F))
        {
            myAnim.SetBool("steinWurf", true);

        }
        else
        {
            myAnim.SetBool("steinWurf", false);
        }
        //Spieler Armbrust Pfeilshuss nur bei Anim armbrust glaube ich :)
        if (Input.GetKeyDown(KeyCode.V))
        {
            PfeilSchuss();
            myAnim.SetBool("armBrustShoot", true);
        }
        else
        {
            myAnim.SetBool("armBrustShoot", false);
        }
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRb.AddForce(new Vector2(0, jumpHeigth));
        }
    }
    // Update is called once per frame
    void FixedUpdate() {
        //check if we grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        myAnim.SetFloat("verticalSpeed", myRb.velocity.y);

        //Move code
        float move = Input.GetAxis("Horizontal");
        //verknüpfung zu anim
        myAnim.SetFloat("speed", Mathf.Abs(move));
        //rechts links bewegung
        myRb.velocity = new Vector2(move * maxGeschwindigkeit, myRb.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        } else if (move < 0 && facingRight) {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        //Scale ist x,y,(z) deswegen Vector 3
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }







    //Angriffe
    void PfeilSchuss()
    {
        if (grounded)
        {
            if (Time.time > nextSchuss)
            {
                nextSchuss = Time.time + schussRate;
            }
            if (facingRight)
            {
                Instantiate(pfeil, schussPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(pfeil, schussPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
       
    }
   

}
