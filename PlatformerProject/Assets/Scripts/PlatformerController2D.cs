// <copyright file="PlayerInputModule2D.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>07/14/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for general purpose 2D controls for any object that can move and jump when grounded.
/// Based on Benno Lueders' PlatformerController2D.cs script.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerController2D : MonoBehaviour {

    [HideInInspector] public Vector2 inputMove;
    [HideInInspector] public bool inputPhase;

    [Tooltip("Can this object move.")]
    public bool canMove = true;

    [Header("Controls")]
    [Tooltip("Base maximum horizontal movement speed.")]
    [SerializeField] float speed = 5;

    [Tooltip("Downwards acceleration.")]
    [SerializeField] float gravity = 40;

    bool isSolid = true;

    Rigidbody2D rb2d = null;
    SpriteRenderer sr = null;
    Animator anim = null;

    void Start() {
        canMove = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        isSolid = true;
    }

    /// <summary>
    /// Controls the basic update of the controller. This uses fixed update, since the movement is physics driven and has to be synched with the physics step.
    /// </summary>
    void FixedUpdate() {
        Vector2 vel = rb2d.velocity;

        if (canMove) vel.x = inputMove.x * speed;

        vel.y += -gravity * Time.deltaTime;
        rb2d.velocity = vel;

        if (inputPhase) isSolid = !isSolid;

        if (isSolid) { rb2d.gravityScale = (float)(-0.1 * gravity - .1); }
        else { rb2d.gravityScale = 1; }
    }

    /// <summary>
    /// Pushback the object controlled by this instance with the specified force.
    /// </summary>
    /// <param name="force">Force to push the character back</param>
    public void Pushback(Vector2 force) {
        rb2d.velocity = force;
    }
}
