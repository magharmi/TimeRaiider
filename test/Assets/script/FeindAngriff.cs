using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpielerNahKampf : MonoBehaviour {

    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Shake shake;

    public Transform attackPos;
    public float attackRange;
    public int damage;

    public LayerMask whatIsEnemies;
    // Use this for initialization
    void Start()
    {
        //shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimeBtwAttack <= 0)
        {


            if (Input.GetKeyDown(KeyCode.T))
            {
                // shake.CamShake();


                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {

                    enemiesToDamage[i].GetComponent<FeindLebenTrex>().addDamage(damage);

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
