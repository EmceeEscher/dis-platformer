using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public Sprite upSprite;
	public Sprite downSprite;
    public Door doorController;
    public float doorCloseDelay = 1f;

	SpriteRenderer sr;
    float doorCloseTimer;
    bool shouldClose;
    int numObjectsOnButton;

	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		sr.sprite = upSprite;
        doorCloseTimer = 0f;
        shouldClose = false;
        numObjectsOnButton = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		sr.sprite = downSprite;
        doorController.OpenDoor();
        doorCloseTimer = 0f;
        numObjectsOnButton++;
        shouldClose = false;
	}

	void OnCollisionExit2D (Collision2D collision) {
        numObjectsOnButton--;
        if (numObjectsOnButton == 0)
        {
            shouldClose = true;
        }
	}

	// Update is called once per frame
	void Update () {
        if (shouldClose)
        {
            doorCloseTimer += Time.deltaTime;
        }
        if (doorCloseTimer > doorCloseDelay)
        {
            sr.sprite = upSprite;
            doorController.CloseDoor();
            shouldClose = false;
            doorCloseTimer = 0f;
        }
    }
}
