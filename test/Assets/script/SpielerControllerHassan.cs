using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerControllerHassan : MonoBehaviour
{

    private static SpielerControllerHassan instance;

    private Animator myAnimator;

    [SerializeField]
    private Transform steinPos,pfeilPos;

    [SerializeField]
    private float speed;

 
    [SerializeField]
    private GameObject stein,pfeil;

   
  
     private bool facingRight;

    [SerializeField]
    private LayerMask whatIsGround;



    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRadius;

    
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool airControl;

    public Rigidbody2D MyRigidbody { get; set; }
    public bool Attack { get; set; }
    public bool  Slide { get; set; }
    public bool  Jump { get; set; }
    public bool OnGround { get; set; }

    public static  SpielerControllerHassan Instance
    {
        get
        {
            if (instance == null)
            {
                return instance = GameObject.FindObjectOfType<SpielerControllerHassan>();
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    void Start()
    {
        facingRight = true;
        MyRigidbody = GetComponent <Rigidbody2D>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        HandleInput();
       
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        OnGround = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
      
        HandleLayers();
      
    }


    private void HandleMovement(float horizontal)
    {
       if(MyRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("isLand", true);
        }

        if (!Attack && !Slide || (OnGround || airControl))
        {
            MyRigidbody.velocity = new Vector2(horizontal * speed, MyRigidbody.velocity.y);
        }
        if (Jump && MyRigidbody.velocity.y == 0)
        {
            MyRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetTrigger("isJump");
            SoundManagerScript.PlaySound("jump");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            myAnimator.SetTrigger("isAttack");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            myAnimator.SetTrigger("isSlide");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            myAnimator.SetTrigger("isSteinWurf");
            SoundManagerScript.PlaySound("steinwurf");
            //  SteinWurf(0);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            myAnimator.SetTrigger("isArmBrust");
            //  SteinWurf(0);
            SoundManagerScript.PlaySound("crossbow");
        }
    }


    private void Flip(float horizontal)
    {
        if (horizontal > 0&&!facingRight||horizontal<0&&facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
  
    private bool IsGrounded()
    {
        if (MyRigidbody.velocity.y <= 0 )
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for(int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                       
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void HandleLayers()
    {
        if (!OnGround)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
    public void SteinWurf(int value)
    {
      //  if (!OnGround && value == 1 || OnGround && value == 0)
        //{

            if (facingRight)
            {
                GameObject tem = (GameObject)Instantiate(stein, steinPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tem.GetComponent<SteinController>().Initialize(Vector2.right);
            }

            else
            {
                GameObject tem = Instantiate(stein, steinPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tem.GetComponent<SteinController>().Initialize(Vector2.left);
            }
        //}
    }
    
    public void PfeilSchuss(int value)
    {
        if (!OnGround && value == 1 || OnGround && value == 0)
        {

            if (facingRight)
            {
                GameObject tem = (GameObject)Instantiate(pfeil, pfeilPos.position, Quaternion.Euler(new Vector3(0, 0, -90)));
                tem.GetComponent<SteinController>().Initialize(Vector2.right);
            }

            else
            {
                GameObject tem = Instantiate(pfeil, pfeilPos.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                tem.GetComponent<SteinController>().Initialize(Vector2.left);
            }
        }
    }
}
