using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//zugriff auf die scene
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    public lvlmanager Lvlmanager;
    public GameObject[] resetObjekt;

    private Vector3[] originalPosition;
    private Quaternion[] originalRotation;
    private Rigidbody2D[] objektBody;
    private bool gehitted = false;

    private void Start()
    {
        Lvlmanager = FindObjectOfType<lvlmanager>();
        originalPosition = new Vector3[resetObjekt.Length];
        originalRotation = new Quaternion[resetObjekt.Length];
        objektBody = new Rigidbody2D[resetObjekt.Length];
        for (int i = 0; i < resetObjekt.Length; i++)
        {
            originalPosition[i] = resetObjekt[i].transform.position;
            originalRotation[i] = resetObjekt[i].transform.rotation;
            objektBody[i] = resetObjekt[i].GetComponent<Rigidbody2D>();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        //Debug.Log("spieler tot");
        if (other.tag == "spieler")
        {

            Debug.Log("spieler tot");
            Lvlmanager.RespawnSpieler();
            for (int i = 0; i < resetObjekt.Length; i++)
            {
                objektBody[i].velocity = Vector3.zero;
                objektBody[i].bodyType = RigidbodyType2D.Static;
                resetObjekt[i].transform.position = originalPosition[i];
                resetObjekt[i].transform.rotation = originalRotation[i];
                objektBody[i].bodyType = RigidbodyType2D.Kinematic;
            }

        }
        else
        {
            Debug.Log("war nicht der spieler");
        }
    }

}
