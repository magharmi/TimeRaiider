using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisKampf : MonoBehaviour {

    private GameObject anubis;
    private Vector3 startPosition;
    private bool anubisZurück = false;
    private bool mumienSpawnen = false;

	// Use this for initialization
	void Start () {
        anubis = GameObject.FindGameObjectWithTag("Boss");
        startPosition = anubis.transform.position;
}
	
	// Update is called once per frame
	void Update () {
		if(anubis.GetComponent<GegnerAI>().leben == 350)
        {
            if (anubisZurück == false)
            {
                anubis.GetComponent<GegnerAI>().speed = 0;
                anubis.transform.position = Vector2.MoveTowards(anubis.transform.position, startPosition, 7 * Time.deltaTime);
                anubis.GetComponent<GegnerAI>().leben = 350;
                if (anubis.transform.position == startPosition)
                {
                    Debug.Log("Anubis zurück");
                    anubisZurück = true;
                    mumienSpawnen = true;
                }
            }
            else if (mumienSpawnen == true)
            {
                //MUMIEN SPAWNEN FUNKTION!!!
                mumienSpawnen = false;
            }
        }
	}

    public void ersterAnubisAngriff()
    {
        anubis.GetComponent<GegnerAI>().speed = 5;
    }

    

}
