using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceUp : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Only switch if the player is a solid
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.LockSwitch();
            Debug.Log("Entered temp zone");
            if(objectWithStates.physicalState == PlatformerController2D.State.Down) objectWithStates.SwitchStates();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.UnlockSwitch();
            Debug.Log("Exited temp zone");
        }
    }
}
