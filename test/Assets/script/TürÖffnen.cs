using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TürÖffnen : MonoBehaviour {

    public GameObject oben, unten, sOben, sUnten;

    private bool wirdGeöffnet, wirdGeschlossen, istGeöffnet, istGeschlossen;
    private Vector3 obenZiel, untenZiel, sUntenZiel, sObenZiel;

    void Update()
    {
        if(wirdGeöffnet == true)
        {
            Debug.Log("Tür wird geöffnet");
            bewegeTür(5);
            if(Vector3.Distance(oben.transform.position, obenZiel) == 0)
            {
                istGeöffnet = true;
            }
        }
        else if(wirdGeschlossen == true)
        {
            Debug.Log("Tür wird schließen");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "spieler")
        {
            türPositionenSetzenÖffnen();
            if (istGeöffnet == false)
                wirdGeöffnet = true;
            else
                wirdGeschlossen = true;
        }
    }

    private void bewegeTür(float zeit)
    {
        if (istGeöffnet == false)
        {
            oben.transform.position = Vector3.MoveTowards(oben.transform.position, obenZiel, zeit * Time.deltaTime);
            unten.transform.position = Vector3.MoveTowards(unten.transform.position, untenZiel, zeit * Time.deltaTime);
            sUnten.transform.position = Vector3.MoveTowards(sUnten.transform.position, sUntenZiel, zeit * Time.deltaTime);
            sOben.transform.position = Vector3.MoveTowards(sOben.transform.position, sObenZiel, zeit * Time.deltaTime);
        }
    }

    private void türPositionenSetzenÖffnen()
    {
        obenZiel = new Vector3(oben.transform.position.x, oben.transform.position.y + (float) 5, oben.transform.position.z);
        untenZiel = new Vector3(unten.transform.position.x, unten.transform.position.y + (float)-5, unten.transform.position.z);
        sUntenZiel = new Vector3(sUnten.transform.position.x, sUnten.transform.position.y + (float)-1, sUnten.transform.position.z);
        sObenZiel = new Vector3(sOben.transform.position.x, sOben.transform.position.y + (float)1, sOben.transform.position.z);
        Debug.Log("Türposition gesetzt");
    }

    private void türPositionenSetzenSchließen()
    {
        obenZiel = new Vector3(oben.transform.position.x, oben.transform.position.y + (float)-5, oben.transform.position.z);
        untenZiel = new Vector3(unten.transform.position.x, unten.transform.position.y + (float)5, unten.transform.position.z);
        sUntenZiel = new Vector3(sUnten.transform.position.x, sUnten.transform.position.y + (float)1, sUnten.transform.position.z);
        sObenZiel = new Vector3(sOben.transform.position.x, sOben.transform.position.y + (float)-1, sOben.transform.position.z);
        Debug.Log("Türposition gesetzt");
    }
}
