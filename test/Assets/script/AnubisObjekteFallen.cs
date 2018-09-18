using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisObjekteFallen : MonoBehaviour
{
    public int zeitBisZerstoerung;
    public float dauer = 2;
    public GameObject[] fallendeObjekte;
    public bool objektRespawnen = false;
    public bool objektZerstören = true;
    public float zeitBisRespawn;
    public bool triggerZerstören = false;
    public AnubisKampf anubisKampfController;

    private Rigidbody2D objekt;
    private Vector3[] anfangsPosition;

    // Use this for initialization
    void Start()
    {
        anfangsPosition = new Vector3[fallendeObjekte.Length];
        anubisKampfController = GetComponent<AnubisKampf>();
        for (int i = 0; i < fallendeObjekte.Length; i++)
        {
            //   anfangsPosition[i] = fallendeObjekte[i].transform.position;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D trigger)
    {
        if (trigger.collider.tag == "spieler")
        {

            if (triggerZerstören == true)
            {
                gameObject.GetComponent<AnubisObjekteFallen>().enabled = false;
            }

            //Plattform nach unten fallen
            Debug.Log("Spieler erkannt - Objekte fallen");
            StartCoroutine(Fall());
            if (objektZerstören == true)
            {
                StartCoroutine(Warte());
            }
        }

    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(dauer);

        for (int i = 0; i < fallendeObjekte.Length; i++)
        {
            objekt = fallendeObjekte[i].GetComponent<Rigidbody2D>();
            objekt.isKinematic = false;
            //objekt.WakeUp();
        }

        yield return new WaitForSeconds(zeitBisRespawn);
        if (objektRespawnen == true)
        {
            for (int i = 0; i < fallendeObjekte.Length; i++)
            {
                fallendeObjekte[i].transform.position = anfangsPosition[i];

            }
            Debug.Log("hat gerespawnt");

            StartCoroutine(Fall());
        }
    }

    IEnumerator Warte()
    {
        yield return new WaitForSeconds(zeitBisZerstoerung);
        for (int i = 0; i < fallendeObjekte.Length; i++)
        {
            Destroy(fallendeObjekte[i]);
        }
        anubisKampfController.ersterAnubisAngriff();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Killzone")
        {
            //Destroy(fallendeObjekte);
        }
    }

}
