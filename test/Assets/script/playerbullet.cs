using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbullet : MonoBehaviour {

    //spawn finden
    public Transform bulletspawn;

    public Rigidbody2D bulletPrefab;
    Rigidbody2D clone;

    public float bulletSpeed = 300f;

    public Transform player;

	// Use this for initialization
	void Start ()
    {
        bulletspawn = GameObject.Find("BULLETSPAWN").transform;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //feuern
            Debug.Log("bam");
            Attack();
            
        }

    }
        void Attack()
        {


           if (bulletspawn.position.x > player.position.x)
            {
                clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
                //rechts werfen
                clone.AddForce(bulletspawn.transform.right * bulletSpeed);
            }
            else
            {
                //Links werfen
               clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
                clone.AddForce(bulletspawn.transform.right * -bulletSpeed);

             }
        }
		
	
}
