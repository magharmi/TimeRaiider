using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandwurm : MonoBehaviour {


    // 1  rechts herum sonst links 
    public int r;
    public int speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (r == 1)
        {
            transform.Rotate(0, 0, -speed);
        }
        else if (r != 1)
        {
            transform.Rotate(0, 0, speed);
        }
    }
}
