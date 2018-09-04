using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryNächstesBild : MonoBehaviour {


    SpriteRenderer spriteRenderer;
    private int bildNummer = 0;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NächstesBild(Sprite neuesBild)
    {
        Debug.Log("Klick");
        spriteRenderer.sprite = neuesBild;
        Destroy(GameObject.Find("1"));
    }
}
