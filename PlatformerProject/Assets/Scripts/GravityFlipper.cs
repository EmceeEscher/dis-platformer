using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.LockSwitch();
            Debug.Log("Entered temp zone");
            objectWithStates.SwitchStates();
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        PlatformerController2D objectWithStates = collider.GetComponent<PlatformerController2D>();
        if (objectWithStates != null)
        {
            objectWithStates.UnlockSwitch();
            Debug.Log("Exited temp zone");
            objectWithStates.SwitchStates();
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
