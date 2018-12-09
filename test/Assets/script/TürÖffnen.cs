using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TürÖffnen : MonoBehaviour {

    public GameObject oben, unten, sOben, sUnten;

    private Vector3 obenStart, untenStart, sUntenStart, sObenStart;
    private Vector3 obenZielOffen, untenZielOffen, sUntenZielOffen, sObenZielOffen;
    private Vector3 obenAktuell, untenAktuell, sUntenAktuell, sObenAktuell;
    private bool geoeffnet, spielerImTrigger;

    private void Start()
    {
        tuerStartPositionenSetzen();
        tuerZielPositionenSetzenOeffnen();
    }

    private void Update()
    {
        if (geoeffnet == false && spielerImTrigger == true)
        {
            bewegeTuer(3, false);
        }
        else if (geoeffnet == true && spielerImTrigger == false){
            bewegeTuer(3, true);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            geoeffnet = false;
            spielerImTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            geoeffnet = true;
            spielerImTrigger = false;
        }
    }

    private void tuerZielPositionenSetzenOeffnen()
    {
        obenZielOffen = new Vector3(obenStart.x, obenStart.y + 5, obenStart.z);
        untenZielOffen = new Vector3(untenStart.x, untenStart.y + -5, untenStart.z);
        sUntenZielOffen = new Vector3(sUntenStart.x, sUntenStart.y + -2, sUntenStart.z);
        sObenZielOffen = new Vector3(sObenStart.x, sObenStart.y + 2, sObenStart.z);
        Debug.Log("Zielpositionen gesetzt (Öffnen)");
    }

    private void tuerStartPositionenSetzen()
    {
        obenStart = oben.transform.position;
        untenStart = unten.transform.position;
        sUntenStart = sUnten.transform.position;
        sObenStart = sOben.transform.position;

        obenAktuell = obenStart;
        untenAktuell = untenStart;
        sUntenAktuell = sUntenStart;
        sObenAktuell = sObenStart;
        Debug.Log("Startpositionen gesetzt");
    }

    private void bewegeTuer(float zeit, bool istOffen)
    {
        if (istOffen == false)
        {
            oben.transform.position = Vector3.MoveTowards(oben.transform.position, obenZielOffen, zeit * Time.deltaTime);
            unten.transform.position = Vector3.MoveTowards(unten.transform.position, untenZielOffen, zeit * Time.deltaTime);
            sOben.transform.position = Vector3.MoveTowards(sOben.transform.position, sObenZielOffen, zeit/2 * Time.deltaTime);
            sUnten.transform.position = Vector3.MoveTowards(sUnten.transform.position, sUntenZielOffen, zeit/2 * Time.deltaTime);
            Debug.Log("Öffne Türen");
            if (Vector3.Distance(oben.transform.position, obenZielOffen) == 0 && Vector3.Distance(unten.transform.position, untenZielOffen) == 0 && Vector3.Distance(sOben.transform.position, sObenZielOffen) == 0 && Vector3.Distance(sUnten.transform.position, sUntenZielOffen) == 0)
            {
                geoeffnet = true;
                Debug.Log("Angekommen (geöffnet)");
            }
        }
        else if (istOffen == true)
        {
            oben.transform.position = Vector3.MoveTowards(oben.transform.position, obenStart, zeit * Time.deltaTime);
            unten.transform.position = Vector3.MoveTowards(unten.transform.position, untenStart, zeit * Time.deltaTime);
            sOben.transform.position = Vector3.MoveTowards(sOben.transform.position, sObenStart, zeit / 2 * Time.deltaTime);
            sUnten.transform.position = Vector3.MoveTowards(sUnten.transform.position, sUntenStart, zeit / 2 * Time.deltaTime);
            Debug.Log("Schließe Tür");
            if(Vector3.Distance(oben.transform.position, obenStart) == 0 && Vector3.Distance(unten.transform.position, untenStart) == 0 && Vector3.Distance(sOben.transform.position, sObenStart) == 0 && Vector3.Distance(sUnten.transform.position, sUntenStart) == 0)
            {
                geoeffnet = false;
                Debug.Log("Angekommen (geschlossen)");
            }
        }
    }

}
