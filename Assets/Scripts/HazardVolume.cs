﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardVolume : MonoBehaviour
{
    [SerializeField] public Text loseText = null;
    [SerializeField] public Text menuText = null;

    private AudioSource _soundKill;

    private void Awake()
    {
        loseText.enabled = false;
        menuText.enabled = false;
        _soundKill = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // detect if it's the player
        PlayerShip playerShip = other.gameObject.GetComponent<PlayerShip>();
        // if we found player, continue
        if (playerShip != null)
        {
            // if player is not invincible
            if (playerShip._invincibility == false)
            {
                Debug.Log("Die!");
                // kill player
                playerShip.Kill();
                _soundKill.Play();

                Destroy(gameObject, 1f);
                loseText.enabled = true;
                menuText.enabled = true;
            } else { Debug.Log("Invincible!"); }
       
        }
    }
}
