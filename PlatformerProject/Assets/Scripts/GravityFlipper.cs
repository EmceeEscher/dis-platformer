using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlipper : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlatformerController2D controller = other.gameObject.GetComponent<PlatformerController2D>();
            controller.FlipGravity();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
