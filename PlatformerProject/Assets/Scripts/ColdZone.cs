using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Only switches if the player is a gas
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null && objectWithStates.physicalState == PlatformerController2D.State.Gas)
        {
            objectWithStates.LockSwitch();
            Debug.Log("Entered temp zone");
            objectWithStates.SwitchStates();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.UnlockSwitch();
            Debug.Log("Exited temp zone");
        }
    }

}
