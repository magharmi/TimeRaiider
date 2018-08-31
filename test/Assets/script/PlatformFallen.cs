using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallen : MonoBehaviour {

    private Rigidbody2D rb2dPlatform;
    public float dauer = 2;
    private GameObject platform;
    public bool PlattformBewegenDeaktivieren = true;

	// Use this for initialization
	void Start ()
    {
        rb2dPlatform = GetComponent<Rigidbody2D>();
        platform = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "spieler")
        {

            //Plattform nach unten fallen
            Debug.Log("Spieler erkannt - Plattform fällt");
            StartCoroutine(Fall());
        }

    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(dauer);
        if (PlattformBewegenDeaktivieren == true)
        {
            gameObject.GetComponent<PlatformBewegen>().enabled = false;
        }
        rb2dPlatform.isKinematic = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Killzone")
        {
            Destroy(platform);
        }
    }

}
