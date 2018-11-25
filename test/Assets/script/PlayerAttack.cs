using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
   
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    //public Animator camAnim;
   private Animator anim;
    public Transform attackPos;
    public float attackRange;
    public int damage;
   
    public LayerMask whatIsEnemies;
    // Use this for initialization
    void Start()
    {
   anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeBtwAttack <= 0)
        {
             if (Input.GetKeyDown(KeyCode.V))
            {
                 anim.SetTrigger("isArmbrust");
            }
            if (Input.GetKeyDown(KeyCode.T))
            {
               // camAnim.SetTrigger("shake");
              anim.SetTrigger("Attack_Speer");
                
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                   
//                    enemiesToDamage[i].GetComponent<EnemyHealthBar>().addDamage(damage);
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


