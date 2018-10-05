using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Flip no matter what state the player is in
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.LockSwitch();
            objectWithStates.SwitchStates();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.UnlockSwitch();
        }
    }

}
