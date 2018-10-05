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
public class PlatformerController2D : MonoBehaviour
{

    public enum State
    {
        Down,
        Up,
        Dead,
    }
    public State physicalState;
    //Listens for input  and functions that lock and unlock states
    private bool locked;

    [HideInInspector] public Vector2 inputMove;
    [HideInInspector] public bool inputPhase;

    [Tooltip("Can this object move.")]
    public bool canMove = true;

    [Header("Controls")]
    [Tooltip("Base maximum horizontal movement speed.")]
    [SerializeField] float speed = 5;

    [Tooltip("Downwards acceleration.")]
    [SerializeField] float gravity = 40;

    Rigidbody2D rb2d = null;
    SpriteRenderer sr = null;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // this has to be in Update instead of FixedUpdate or else it will 
        // occasionally miss switches
        if (inputPhase && !locked)
        {
            SwitchStates();
        }
    }

    /// <summary>
    /// Controls the basic update of the controller. This uses fixed update, since the movement 
    /// is physics driven and has to be synched with the physics step.
    /// </summary>
    void FixedUpdate()
    {
        Vector2 vel = rb2d.velocity;

        if (canMove) { 
            vel.x = inputMove.x * speed; 
        }

        switch (physicalState){
            case State.Down:
                vel.y += -gravity * Time.deltaTime;
                break;
            case State.Up:            
                vel.y += gravity * Time.deltaTime;
                break;
        }
        rb2d.velocity = vel;
    }

    public void SwitchStates()
    {
        if (physicalState == State.Down)
        {
            physicalState = State.Up;
        }
        else
        {
            physicalState = State.Down;
        }
    }

    public void SetToState(State newState)
    {
        physicalState = newState;
    }

    //prevent player from switching states
    public void LockSwitch()
    {
        locked = true;
    }

    //unlock ability to switch states
    public void UnlockSwitch()
    {
        locked = false;
    }

}
