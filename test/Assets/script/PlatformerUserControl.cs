﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(PlatformerCharacter))]
public class PlatformerUserControl : MonoBehaviour
{
    private PlatformerCharacter m_Character;
    private bool m_Jump;
    private DialogueManager dialogueManager;
    
    

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        //Mein befehl
        bool c = Input.GetKey(KeyCode.V);
       
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, crouch, m_Jump);
        m_Jump = false;
    }
}