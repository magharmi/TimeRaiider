using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    float dirX;
    [SerializeField]
    float moveSpeed = 3f;
    Transform spielerK;
    Rigidbody2D rb;

    bool facingRight = false;

    Vector3 localScale;
    public static bool isAttacking = false;

    // Use this for initialization
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        spielerK = GameObject.FindGameObjectWithTag("spieler").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < spielerK.transform.position.x)
            dirX = -1f;
        else if (transform.position.x > spielerK.transform.position.x)
            dirX = 1f;
       
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
}
