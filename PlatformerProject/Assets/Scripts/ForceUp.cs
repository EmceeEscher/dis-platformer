using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUp : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D collider)
    {
        // Only switch if the player is in the Down state
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.LockSwitch();
            if(objectWithStates.physicalState == PlatformerController2D.State.Down) objectWithStates.SwitchStates();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.UnlockSwitch();
        }
    }
}
