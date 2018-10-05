using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // for testing

public class BlowItems : MonoBehaviour {
    // Inspired by user GameDevGuy @ http://wiki.unity3d.com/index.php/WindComponent

    // Directional force
    public Vector2 windForce = Vector2.zero;
    // Internal list that tracks objects in fan zone
    private List<Collider2D> affectedItems = new List<Collider2D>();

    private void FixedUpdate()
    {
        foreach(Collider2D item in affectedItems) {
            Rigidbody2D body = item.attachedRigidbody;
            body.AddForce(windForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D item)
    {
        affectedItems.Add(item);
    }

    private void OnTriggerExit2D(Collider2D item)
    {
        affectedItems.Remove(item);
    }
}
