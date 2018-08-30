using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

    public MovieTexture movie;


	// Use this for initialization
	void Start ()
    {
        movie.Play();	 Fall();
	} 
	
	// Update is called once per frame
	void Update () {

       
		
	}

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(9);
     SceneManager.LoadScene("Hauptmenü");
    }
}
