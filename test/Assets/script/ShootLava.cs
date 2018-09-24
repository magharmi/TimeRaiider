using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLava : MonoBehaviour {

    public GameObject lavaStein;

    public float shootTime;
    public int chanceShoot;
    public Transform shootfrom;

    float nexShootTime;

    //Animator lavaanim;

	// Use this for initialization
	void Start () {
        // lavaanim = GetComponentInChildren<Animator>();
        nexShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "spieler" && nexShootTime < Time.time)
        {
            nexShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            

                Instantiate(lavaStein, shootfrom.position, Quaternion.identity);
                //lavaanim.SetTrigger("cannonShoot");
            }
        }

 }

     

