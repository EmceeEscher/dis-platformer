using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTile : MonoBehaviour {

    [SerializeField] SceneController reloader;
    public AudioClip clip;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.collider.GetComponent<Player>().Die();
            // play sound
            audio.PlayOneShot(clip);
            if (reloader != null) {
                StartCoroutine(reloader.ReloadLevel());
            }

        }
    }
}
