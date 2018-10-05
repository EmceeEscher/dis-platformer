using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceDown : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Only switches if the player is in the Up state
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.LockSwitch();
            if(objectWithStates.physicalState == PlatformerController2D.State.Up) objectWithStates.SwitchStates();
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
