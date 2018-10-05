using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource audio;
   

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision with block");

        if (col.gameObject.tag == "Player") {
            Debug.Log("Player colliding with block");
            audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
}
