using System;
using UnityEngine;


public class PlatformerCharacter : MonoBehaviour
{

    float nextFire, fireRate;
    [SerializeField] Transform pfeilPos;
    [SerializeField] GameObject pfeil;
    [SerializeField] Transform akPos;
    [SerializeField] Transform pistolPos;
    [SerializeField] Transform shootPos;
    [SerializeField] GameObject akGeschoss;
    
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
  
    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    //AKT1 bool
    bool speer,knochen1,knochen2,axt,keule1;
    //Akt2 bool
    bool isAkt2_Schwert, isAkt2_Schwert1, isAkt2_Schwert3, isAkt2_Schwert4;
    //Akt3 bool
    bool isAkt3_Schwert,isAkt3_Axt, isAkt2_Schwert2,isAkt3_Keule, isSchwertMongol;
    //Akt4
    bool isAkt4_Ak, isAkt4_Pistol, isShoot;
    //public Inventory inventory;
    //Waffe Wechseln mit animation

    public int selectedWeapon = 0;
    private void Awake()
    {

        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        HanldeInputAKt1();
        HanldeInputAKt2();

        if (Input.GetKeyDown(KeyCode.V))
        {
            m_Anim.SetTrigger("isArm");
            Armbrust();
        }
   
    }

    private void FixedUpdate()
    {

        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        m_Anim.SetBool("Ground", m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);


    }


    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch && m_Anim.GetBool("Crouch"))
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        // Set whether or not the character is crouching in the animator
        m_Anim.SetBool("Crouch", crouch);

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {
            // Reduce the speed if crouching by the crouchSpeed multiplier
            move = (crouch ? move * m_CrouchSpeed : move);

            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }
    //==============================================AKT1=AKT2=AKT3=AKT4=====================================================================//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("keule"))
        {
            keule1 = true;
            HanldeInputAKt1();
        }
        if (collision.gameObject.CompareTag("speer"))
        {
            speer = true;
            HanldeInputAKt1();
        }
        if (collision.gameObject.CompareTag("KnochenKeule1"))
        {
            knochen1 = true;
            HanldeInputAKt1();
        }
      
        if (collision.gameObject.CompareTag("KnochenKeule2"))
        {
            knochen2 = true;
            HanldeInputAKt1();
        }
        if (collision.gameObject.CompareTag("SteinZeitAxt"))
        {
            axt = true;
            HanldeInputAKt1();
        }
        //==============================================AKT1===ENDE=======================================================================//
        //==============================================AKT2================================================================================//
        // isAkt2_Schwert, isAkt2_Schwert1, isAkt2_Schwert3
        if (collision.gameObject.CompareTag("Schwert1"))
        {
            isAkt2_Schwert = true;
            HanldeInputAKt2();
        }
        if (collision.gameObject.CompareTag("Schwert2"))
        {
            isAkt2_Schwert1 = true;
            HanldeInputAKt2();
        }
        if (collision.gameObject.CompareTag("Schwert3"))
        {
            isAkt2_Schwert3 = true;
            HanldeInputAKt2();
        }

        if (collision.gameObject.CompareTag("Schwert4"))
        {
            isAkt2_Schwert4 = true;
            HanldeInputAKt2();
        }
        //==============================================AKT3===============================================================================//
        //isAkt3_Schwert,isAkt3_Axt,isAkt3_Keule, isSchwertMongol
        if (collision.gameObject.CompareTag("SchwertRom"))
        {
            isAkt3_Schwert = true;
            HanldeInputAKt3();
        }
        if (collision.gameObject.CompareTag("AxtRom"))
        {
            isAkt3_Axt = true;
            HanldeInputAKt3();
        }
        if (collision.gameObject.CompareTag("KeuleRom"))
        {
            isAkt3_Keule = true;
            HanldeInputAKt3();
        }
        //Muss noch als pickup installiert werden
        if (collision.gameObject.CompareTag("isSchwertMongol"))
        {
            isSchwertMongol = true;
            HanldeInputAKt3();
        }
        //==============================================AKT3====ENDE========================================================================//
        //==============================================AKT4================================================================================//
        if (collision.gameObject.CompareTag("AK"))
        {
            isAkt4_Ak = true;
            HanldeInputAKt4();
        }
        if (collision.gameObject.CompareTag("Pistole"))
        {
            isAkt4_Pistol = true;
            HanldeInputAKt4();
        }
        if (collision.gameObject.CompareTag("pumpgun"))
        {
            isShoot = true;
            HanldeInputAKt4();
        }
    }
    //==============================================AKT1====================================================================================//
    void HanldeInputAKt1()
    {
        if (keule1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                m_Anim.SetTrigger("isKeule");
               
            }
        }
        if (speer)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                m_Anim.SetTrigger("isSpeer");
            }
        }
        if (knochen1)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                m_Anim.SetTrigger("isKnochen");
            }
        }
        if (knochen2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                m_Anim.SetTrigger("isKnochen1");
            }
        }
        if (axt)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
               
                m_Anim.SetTrigger(" isAxtAngriff");
            }
        }
    }
    //==============================================AKT1====ENDE========================================================================//
    //
    //==============================================AKT2================================================================================//
    void HanldeInputAKt2()
    {
        if (isAkt2_Schwert)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                m_Anim.SetTrigger("isAkt2_Schwert");

            }
        }
        if (isAkt2_Schwert1)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                m_Anim.SetTrigger("isAkt2_Schwert1");
            }
        }
        if (isAkt2_Schwert2)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                m_Anim.SetTrigger("isAkt2_Schwert2");
            }
        }
        if (isAkt2_Schwert3)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                m_Anim.SetTrigger("isAkt2_Schwert3");
            }
        }
        
              if (isAkt2_Schwert4)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                //Muss suchen
                m_Anim.SetTrigger("");
            }
        }
    }
    //==============================================AKT2===ENDE==========================================================================//
    //isAkt3_Schwert,isAkt3_Axt, isAkt3_Keule, isSchwertMongol
    //==============================================AKT3===Start=========================================================================//
    void HanldeInputAKt3()
    {
        if (isAkt3_Schwert)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                m_Anim.SetTrigger("isAkt3_Schwert");

            }
        }
        if (isAkt3_Axt)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                m_Anim.SetTrigger("isAkt3_Axt");
            }
        }
        if (isAkt3_Keule)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                m_Anim.SetTrigger("isAkt3_Keule");
            }
        }
        if (isSchwertMongol)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                m_Anim.SetTrigger("isSchwertMongol");
            }
        }
    }
    //==============================================AKT3===ENDE==========================================================================//
    //isAkt4_Ak, isAkt4_Pistol;
    //==============================================AKT4===Start=========================================================================//
    void HanldeInputAKt4()
    {
        if (isAkt4_Ak)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                m_Anim.SetTrigger("isAkt4_Ak");
                Ak();
            }
        }
        if (isAkt4_Pistol)
        {
            if (Input.GetKeyDown(KeyCode.Mouse2))
            {
                m_Anim.SetTrigger("isAkt4_Pistol");
                Ak();
            }
        }
        if (isShoot)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {

                m_Anim.SetTrigger("isShoot");
            }
        }
       
    }
    //==============================================AKT4===ENDE=========================================================================//
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void spielerGeschwindigkeit(float maxSpeed)
    {
        m_MaxSpeed = maxSpeed;
    }


    public void Armbrust()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (m_FacingRight)
            {

                Instantiate(pfeil, pfeilPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!m_FacingRight)
            {

                Instantiate(pfeil, pfeilPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    public void Ak()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (m_FacingRight)
            {

                Instantiate(akGeschoss, akPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!m_FacingRight)
            {

                Instantiate(akGeschoss, akPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    public void Pistol()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (m_FacingRight)
            {

                Instantiate(akGeschoss, pistolPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                
            }
            else if (!m_FacingRight)
            {

                Instantiate(akGeschoss, pistolPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
              
            }
        }
    }
    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (m_FacingRight)
            {

                Instantiate(akGeschoss, shootPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!m_FacingRight)
            {

                Instantiate(akGeschoss, shootPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }

}
