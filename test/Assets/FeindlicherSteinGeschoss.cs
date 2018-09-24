using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeindlicherSteinGeschoss : MonoBehaviour {
    [SerializeField]
    public float speed;
    [SerializeField]
    GameObject MeinBlut;

    private Transform spieler;
    private Vector2 target;
	// Use this for initialization
	void Start () {
        spieler = GameObject.FindGameObjectWithTag("spieler").transform;
         target = new Vector2(spieler.position.x, spieler.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.y == target.x && transform.position.y == target.y)
        {
            DestroyStein();
        }
	}
    public void OnCollision2D(Collider2D other)
    {
        if (other.CompareTag("spieler"))
        {
            DestroyStein();
        }
    }

    public void DestroyStein()
    {
        Instantiate(MeinBlut, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
