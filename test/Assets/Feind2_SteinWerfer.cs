using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feind2_SteinWerfer : MonoBehaviour {
    [SerializeField]
    public float speed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float TimeBtwShots;

   

    
    Animator myAnimator;

    [SerializeField]
    public GameObject shot;
    private Transform spieler;
 

	// Use this for initialization
	void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler").transform;
       
        myAnimator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //Enemy Move
       
            if (Vector2.Distance(transform.position, spieler.position) < nearDistance)
            {
            
            transform.position = Vector2.MoveTowards(transform.position, spieler.position, -speed * Time.deltaTime);
                
            }
            else if (Vector2.Distance(transform.position, spieler.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, spieler.position, speed * Time.deltaTime);
           
            }
            else if (Vector2.Distance(transform.position, spieler.position) < stoppingDistance && Vector2.Distance(transform.position, spieler.position) > nearDistance)
            {
                transform.position = this.transform.position;
           
            }
           
        
        //Makes the enemy shoot
        if (TimeBtwShots <= 0)
            {
                Instantiate(shot, transform.position, Quaternion.identity);
                TimeBtwShots = startTimeBtwShots;
               
            }
            else
            {
                TimeBtwShots -= Time.deltaTime;
            }
        }



  
}
