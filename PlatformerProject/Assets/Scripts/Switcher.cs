using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Flip no matter what teh states
        PlatformerController2D objectWithStates = collision.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
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
