using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

    public AudioClip[] clips;
    AudioSource audio;
   
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") {
            audio.PlayOneShot(clips[Random.Range(0, clips.Length)]);
        }
    }
}
