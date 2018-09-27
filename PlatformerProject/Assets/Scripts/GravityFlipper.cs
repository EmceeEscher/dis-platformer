using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatus.LockSwitch();
            Debug.Log("Entered temp zone");
            PlayerStatus.SwitchStates();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStatus.UnlockSwitch();
            Debug.Log("Exited temp zone");
            PlayerStatus.SwitchStates();
        }
    }
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
}
