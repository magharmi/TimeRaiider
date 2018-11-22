using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool neuesZielErstellen = false;
    public bool spielerEinfrieren = false;
    public Sprite idleSprite;
    public BoxCollider2D altesZiel = null;
    public BoxCollider2D neuesZiel;
    public Dialogue dialogue;
    public GameObject trigger;

    private GameObject spieler;

    private void Start()
    {
        spieler = GameObject.FindGameObjectWithTag("spieler");
    }

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
            if (neuesZielErstellen == true)
            {
                Destroy(altesZiel);
                neuesZiel.enabled = true;
            }
            if(spielerEinfrieren == true)
            {
                Debug.Log("Deaktivieren");
                //spieler.GetComponent<PlatformerCharacter>().enabled = false;
                spieler.GetComponent<Animator>().enabled = false;
                spieler.GetComponent<PlatformerUserControl>().enabled = false;
                spieler.GetComponent<SpriteRenderer>().sprite = idleSprite;
            }
        }
    }

}
