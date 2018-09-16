using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Animator animator;

    private Queue<string> sentences;
    private GameObject[] gegner;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        gegner = GameObject.FindGameObjectsWithTag("GegnerVonDialogboxAbhängig");
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
            gegner[i].GetComponent<GegnerAI>().enabled = true;
        }
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
