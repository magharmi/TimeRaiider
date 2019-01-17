using System;
using UnityEngine;


public class PlatformerCharacter : MonoBehaviour
{
    //Waffen bild wechseln
   // public GameObject Inventarbild1, Inventarbild2, Inventarbild3;
    public int selectedWeapon = 0;
    //
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
    bool scene1;
    bool speer,knochen1,knochen2,axt;
    //Akt2 bool
    bool isAkt2_Schwert, isAkt2_Schwert1, isAkt2_Schwert3, isAkt2_Schwert4;
    //Akt3 bool
    bool isAkt3_Schwert,isAkt3_Axt, isAkt2_Schwert2,isAkt3_Keule, isSchwertMongol;
    //Akt4
    bool isAkt4_Ak, isAkt4_Pistol, isShoot;
    //public Inventory inventory;
    //Waffe Wechseln mit animation

   
    private void Awake()
    {
        //Akt 1
        scene1   = true;
        knochen1 = false;
        knochen2 = false;
        axt      = false;
        //Akt2
        isAkt2_Schwert  = false;
        isAkt2_Schwert1 = false;
        isAkt2_Schwert3 = false;
       //Akt 4
       isAkt4_Ak = false;
        isAkt4_Pistol = false;
        isShoot = false;


        SelectWeapon();
        akGeschoss.SetActive(false);
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        //Waffewchseln();
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            m_Anim.SetTrigger("isArm");
            Armbrust();
        }
        /*
       if (Input.GetMouseButtonDown(0))
        {
            if (isShoot == true)
                m_Anim.SetTrigger("isShoot");
            Ak();
        }

       if (Input.GetKeyDown(KeyCode.Mouse1))
       {
       if (isAkt4_Pistol == true)

         m_Anim.SetTrigger("isAkt4_Pistol");
        Ak();
       }
        */
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
    void resetAnim()
    {
        isAkt4_Ak = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.tag=="zielitem"){
            scene1 = false;
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
                SoundManagerScript.PlaySound("crossbow");
                Instantiate(akGeschoss, shootPos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!m_FacingRight)
            {

                Instantiate(akGeschoss, shootPos.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    //Waffewchseln
    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
   

}
/*
          //isAkt3_Schwert,isAkt3_Axt, isAkt2_Schwert2,isAkt3_Keule
          if (Input.GetKeyDown(KeyCode.Alpha1))
          {
              isAkt3_Schwert  = true;
              isAkt3_Axt      = false;
              isAkt3_Keule    = false;
              // Inventarbild1.SetActive(true);
              // Inventarbild2.SetActive(false);
              // Inventarbild3.SetActive(false);
          }
          if (Input.GetKeyDown(KeyCode.F))
          {
              if (isAkt3_Schwert == true)

                  m_Anim.SetTrigger("isSchwertMongol");
          }

          ///////////////////////////////////////
          if (Input.GetKeyDown(KeyCode.Alpha2))
          {
              isAkt3_Axt     = true;
              isAkt3_Schwert = false;
              isAkt3_Keule   = false;
              // Inventarbild1.SetActive(true);
              // Inventarbild2.SetActive(false);
              // Inventarbild3.SetActive(false);
          }
          if (Input.GetKeyDown(KeyCode.F))
          {
              if (isAkt3_Axt == true)

                  m_Anim.SetTrigger("isAkt3_Axt");
          }

          ////////////////////////////////////
          if (Input.GetKeyDown(KeyCode.Alpha3))
          {
              isAkt3_Keule   = true;
              isAkt3_Axt     = false;
              isAkt3_Schwert = false;
              // Inventarbild1.SetActive(true);
              // Inventarbild2.SetActive(false);
              // Inventarbild3.SetActive(false);
          }
          if (Input.GetKeyDown(KeyCode.F))
          {
              if (isAkt3_Keule == true)

                  m_Anim.SetTrigger("isAkt3_Keule");
          }

      */




//Steinzeit  speer,knochen1,knochen2,axt
//Inventar1 
/*
if (scene1)
{
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
        axt = false;
        knochen1 = false;

        knochen1 = true;
    }
    if (Input.GetKeyDown(KeyCode.T))
    {
        if (knochen1 == true)

            m_Anim.SetTrigger("isKnochen");
    }

    if (Input.GetKeyDown(KeyCode.Alpha2))
    {

        axt = false;
        knochen1 = false;
        knochen2 = true;
    }
    if (Input.GetKeyDown(KeyCode.T))
    {
        if (knochen2 == true)

            m_Anim.SetTrigger("isKnochen1");
    }

    //Axt
    if (Input.GetKeyDown(KeyCode.Alpha3))
    {

        knochen1 = false;
        knochen2 = false;
        axt = true;
    }
    if (Input.GetKeyDown(KeyCode.T))
    {
        if (axt == true)

            m_Anim.SetTrigger("isAxtAngriff");
    }
}

//Inventar1 
if (Input.GetKeyDown(KeyCode.Alpha1))
{
    isAkt2_Schwert  = true;
    isAkt2_Schwert1 = false;
    isAkt2_Schwert3 = false;
    // Inventarbild1.SetActive(true);
    // Inventarbild2.SetActive(false);
    // Inventarbild3.SetActive(false);

}
if (Input.GetKeyDown(KeyCode.F))
{
    if (isAkt2_Schwert == true)

        m_Anim.SetTrigger("isAkt2_Schwert");
}

//Inventar2 
if (Input.GetKeyDown(KeyCode.Alpha2))
{
    isAkt2_Schwert1 = true;
    isAkt2_Schwert  = false;
    isAkt2_Schwert3 = false;
    // Inventarbild1.SetActive(true);
    // Inventarbild2.SetActive(false);
    // Inventarbild3.SetActive(false);
}
if (Input.GetKeyDown(KeyCode.F))
{
    if (isAkt2_Schwert1 == true)

        m_Anim.SetTrigger("isAkt2_Schwert1");
}

if (Input.GetKeyDown(KeyCode.Alpha3))
{
    isAkt2_Schwert3 = true;
    isAkt2_Schwert = false;
    isAkt2_Schwert1 = false;
    // Inventarbild1.SetActive(true);
    // Inventarbild2.SetActive(false);
    // Inventarbild3.SetActive(false);
}
if (Input.GetKeyDown(KeyCode.F))
{
    if (isAkt2_Schwert3 == true)

        m_Anim.SetTrigger("isAkt2_Schwert3");
}
/*
 //Ak
 //Inventar 1
 if (Input.GetKeyDown(KeyCode.Alpha1))
 {
     isShoot = false;
     isAkt4_Ak = false;
     Inventarbild1.SetActive(true);
     Inventarbild2.SetActive(false);
     Inventarbild3.SetActive(false);
     isAkt4_Pistol = true;
     akGeschoss.SetActive(true);

 }
 if (Input.GetKeyDown(KeyCode.Mouse1))
 {
     if (isAkt4_Pistol == true)

         m_Anim.SetTrigger("isAkt4_Pistol");
     Ak();
 }
 //Inventar 2
 if (Input.GetKeyDown(KeyCode.Alpha2))
 {
     Inventarbild1.SetActive(false);
     Inventarbild3.SetActive(false);
     isShoot = false;
     isAkt4_Pistol = false;

     Inventarbild2.SetActive(true);
     akGeschoss.SetActive(true);
     isAkt4_Ak = true;
 }
 if (Input.GetKeyDown(KeyCode.Mouse1))
 {
     if (isAkt4_Ak == true)

         m_Anim.SetTrigger("isAkt4_Ak");
     Ak();
 }
 //Inventar 3
 if (Input.GetKeyDown(KeyCode.Alpha3))
 {
     Inventarbild1.SetActive(false);
     Inventarbild2.SetActive(false);
     isAkt4_Pistol = false;
     isAkt4_Ak     = false;

     Inventarbild3.SetActive(true);
     akGeschoss.SetActive(true);
     isShoot = true;
 }
 if (Input.GetKeyDown(KeyCode.Mouse1))
 {
     if (isShoot == true)
         m_Anim.SetTrigger("isShoot");
     Ak();
 }
*/
