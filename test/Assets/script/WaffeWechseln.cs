using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaffeWechseln : MonoBehaviour {
    public int selectedWeapon = 0;
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        int previousSelectedWeapon = selectedWeapon;
       /*
        //Waffe wechseln mit maus
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
            selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount -1;
            else
                selectedWeapon--;
        }
        */
        //Waffe wechseln mit tastatur
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&&transform.childCount>=2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
            if (Input.GetKeyDown(KeyCode.L))
            {
                anim.SetTrigger("isSpeer");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && transform.childCount >= 5)
        {
            selectedWeapon = 4;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
