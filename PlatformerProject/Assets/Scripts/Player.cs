using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player script. Manages the graphical state of the player.
/// Based on Benno Lueders' Player.cs script.
/// </summary>
[RequireComponent(typeof(PlatformerController2D))]
public class Player : MonoBehaviour
{
    PlatformerController2D controller;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Destroy the player and spawn the death animation.
    /// </summary>
    public void Die()
    {
        Destroy(gameObject);
    }

    public IEnumerator RunTeleportAnimation(float timeToFade)
    {
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / timeToFade)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(1f, 0f, t));
            sr.color = newColor;
            yield return null;
        }
    }
}