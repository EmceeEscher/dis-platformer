using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public bool isHorizontal = true;
    public float openingDistance = 100f;
    public bool flipDirection = false;

    Vector2 startingPosition;
    Vector2 destinationPosition;
    float doorProgress = 0.0f;
    bool opening = false;
    bool isOpen = false;
    bool closing = false;
    bool isClosed = true;

	// Use this for initialization
	void Start () {
        startingPosition = transform.position;
        destinationPosition = startingPosition;
        if (flipDirection) {
            openingDistance = -openingDistance;
        }
        if (isHorizontal) {
            destinationPosition.x += openingDistance;
        } else {
            destinationPosition.y += openingDistance;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (opening || closing) {
            doorProgress += Time.deltaTime;
            if (doorProgress > 1.0f)
            {
                doorProgress = 1.0f;
            }
            if (opening)
            {
                transform.position = Vector2.Lerp(startingPosition, destinationPosition, doorProgress);
                if (transform.position.Equals(destinationPosition)) {
                    doorProgress = 0.0f;
                    opening = false;
                    isOpen = true;
                }
            } else if (closing) {
                transform.position = Vector2.Lerp(destinationPosition, startingPosition, doorProgress);
                if (transform.position.Equals(startingPosition))
                {
                    doorProgress = 0.0f;
                    closing = false;
                    isClosed = true;
                }
            }
        }
	}

    public void OpenDoor() {
        if (!isOpen)
        {
            opening = true;
            closing = false;
            isClosed = false;
            if (isHorizontal) {
                doorProgress = Mathf.Abs(transform.position.x - startingPosition.x) / openingDistance;
            } else {
                doorProgress = Mathf.Abs(transform.position.y - startingPosition.y) / openingDistance;
            }
        }
    }

    public void CloseDoor() {
        if (!isClosed)
        {
            closing = true;
            opening = false;
            isOpen = false;
            if (isHorizontal)
            {
                doorProgress = Mathf.Abs(transform.position.x - destinationPosition.x) / openingDistance;
            }
            else
            {
                doorProgress = Mathf.Abs(transform.position.y - destinationPosition.y) / openingDistance;
            }
        }
    }
}
