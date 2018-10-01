﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player script. Manages the state and interaction with environment of the player.
/// Based on Benno Lueders' Player.cs script.
/// </summary>
[RequireComponent(typeof(PlatformerController2D))]
public class Player : MonoBehaviour {

    PlatformerController2D controller;
    SpriteRenderer[] sr;

    void Awake() {
        controller = GetComponent<PlatformerController2D>();
        sr = GetComponentsInChildren<SpriteRenderer>();
    }
	
    /// <summary>
    /// Destroy the player and spawn the death animation.
    /// </summary>
    public void Die() {
        Destroy(gameObject);
    }
}
