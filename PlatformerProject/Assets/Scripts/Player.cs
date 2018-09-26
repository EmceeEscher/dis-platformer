using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player script. Manages the state and interaction with environment of the player.
/// Based on Benno Lueders' Player.cs script.
/// </summary>
[RequireComponent(typeof(PlatformerController2D))]
public class Player : MonoBehaviour {

    public enum PlayerStatus {
        Solid,
        Gas,
        Dead,
    }

    PlatformerController2D controller;
    SpriteRenderer[] sr;
    PlayerStatus state;

    void Awake() {
        controller = GetComponent<PlatformerController2D>();
        sr = GetComponentsInChildren<SpriteRenderer>();
        state = PlayerStatus.Solid;
    }
	
    /// <summary>
    /// Destroy the player and spawn the death animation.
    /// </summary>
    public void Die() {
        Destroy(gameObject);
    }
}
