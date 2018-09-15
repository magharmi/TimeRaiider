using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool neuesZielErstellen = false;
    public BoxCollider2D altesZiel = null;
    public BoxCollider2D neuesZiel;
    public Dialogue dialogue;
    public GameObject trigger;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spieler")
        {
            TriggerDialogue();
            trigger.SetActive(false);
        }
        if(neuesZielErstellen == true)
        {
            Destroy(altesZiel);
            neuesZiel.enabled = true;
        }
    }

}
