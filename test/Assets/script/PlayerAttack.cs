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
        Debug.Log(waffennummer);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeBtwAttack <= 0)
        {
           
            if (Input.GetKeyDown(KeyCode.T))
            {
                // camAnim.SetTrigger("shake");
                if (waffennummer == 1)
                {
                    anim.SetTrigger("isAxtAngriff");
                }
                else if (waffennummer == 2)
                {
                    anim.SetTrigger("isKnochen");
                }
                else if (waffennummer == 3)
                {
                    anim.SetTrigger("isKnochen1");
                }
                else if (waffennummer == 0)
                {
                    anim.SetTrigger("isSpeer");
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


