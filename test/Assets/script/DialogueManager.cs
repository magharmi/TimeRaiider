using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public bool GegnerAIVorhanden = false;
    public bool LandwirtRenntWegVorhanden = false;
    public bool NaechstesZiel = false;
    public Animator animator;

    private Queue<string> sentences;
    private GameObject[] gegner;
    private GameObject spieler;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        gegner = GameObject.FindGameObjectsWithTag("GegnerVonDialogboxAbhängig");
        spieler = GameObject.FindGameObjectWithTag("spieler");
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        StartCoroutine(WarteAufAntwort());
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(Timeout());

        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        for(int i = 0; i < gegner.Length; i++)
        {
            if(GegnerAIVorhanden)
                gegner[i].GetComponent<GegnerAI>().enabled = true;
            if(LandwirtRenntWegVorhanden)
                gegner[i].GetComponent<LandwirtRenntWeg>().enabled = true;
        }
        spieler.GetComponent<Animator>().enabled = true;
        spieler.GetComponent<PlatformerUserControl>().enabled = true;
    }

    IEnumerator WarteAufAntwort()
    {
        while (!Input.GetMouseButton(1)){
            yield return null;
        }
        DisplayNextSentence();
    }

    IEnumerator Timeout()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(WarteAufAntwort());
    }

}
