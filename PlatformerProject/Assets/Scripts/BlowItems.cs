using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inspired by user GameDevGuy @ http://wiki.unity3d.com/index.php/WindComponent

public class BlowItems : MonoBehaviour {

    // Directional force
    public Vector2 windForce = Vector2.zero;

    // Internal list that tracks objects in fan zone
    List<Collider2D> affectedItems = new List<Collider2D>();

    void FixedUpdate()
    {
        foreach(Collider2D item in affectedItems) {
            Rigidbody2D body = item.attachedRigidbody;
            body.AddForce(windForce);
        }
    }

    void OnTriggerEnter2D(Collider2D item)
    {
        affectedItems.Add(item);
    }

    void OnTriggerExit2D(Collider2D item)
    {
        affectedItems.Remove(item);
    }
}
