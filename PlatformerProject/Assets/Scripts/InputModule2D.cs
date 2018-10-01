using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Module for player controller input when using a PlatformController2D. Uses standart Horizontal and Vertical input axis as well as Jump button.
/// Based on Benno Lueders' PlayerInputModule2D.cs script.
/// </summary>
[RequireComponent(typeof(PlatformerController2D))]
public class InputModule2D : MonoBehaviour {

    PlatformerController2D controller;

    void Start() {
        controller = GetComponent<PlatformerController2D>();
    }
	
    void FixedUpdate() {
        Vector2 inputMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (inputMove.magnitude > 1) {
            inputMove.Normalize();
        }
        controller.inputMove = inputMove;
        //TODO: Add way to lock switching states when in the zone
        bool inputPhase = Input.GetKeyDown("space");
        controller.inputPhase = inputPhase;
    }
}