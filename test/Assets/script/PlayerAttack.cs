using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
  
    
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public LayerMask whatIsEnemies;
  
   // public float spielerSpeed;
    //public Animator camAnim;
    private Animator anim;
    public Transform attackPos;
    
    public float attackRange;
    public int damage=10;
    private int waffennummer;
   
    //GameObjects
   
    Rigidbody2D m_Rigidbody2D;
 
   

    // Use this for initialization
    void Start()
    {
        waffennummer = PlayerPrefs.GetInt("Waffennummer");
        Debug.Log("Waffennummer: " + waffennummer);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeBtwAttack <= 0)
        {
           
            if (Input.GetKeyDown(KeyCode.F))
            {
                // camAnim.SetTrigger("shake");
                //Akt1
                if (waffennummer == 0)
                {
                    anim.SetTrigger("isKnochen");
                }
                else if (waffennummer == 1)
                {
                    anim.SetTrigger("isKnochen");
                }
                else if (waffennummer == 2)
                {
                    anim.SetTrigger("isAxtAngriff");
                }
                //Akt2
                else if (waffennummer == 3)
                {
                    anim.SetTrigger("isAkt2_Schwert");
                }
                else if (waffennummer == 4)
                {
                    anim.SetTrigger("isAkt2_Schwert1");
                }
                else if (waffennummer == 5)
                {
                    anim.SetTrigger("isAkt2_Schwert3");
                }
                //Akt3
                else if (waffennummer == 6)
                {
                    anim.SetTrigger("isAkt3_Axt");
                }
                else if (waffennummer == 7)
                {
                    anim.SetTrigger("isAkt3_Schwert");
                }
                else if (waffennummer == 8)
                {
                    anim.SetTrigger("isAkt3_Keule");
                }
                //Akt4
                else if (waffennummer == 9)
                {
                    anim.SetTrigger("isShoot");
                }
                else if (waffennummer == 10)
                {
                    anim.SetTrigger("isAkt4_Ak");
                }
                else if (waffennummer == 11)
                {
                    anim.SetTrigger("isAkt4_Pistol");
                }


                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                   
                   enemiesToDamage[i].GetComponent<EnemyHealthBar>().addDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
  
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
  
  
    
   

    

  

}


