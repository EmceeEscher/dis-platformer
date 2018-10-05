using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour {

    public float timeToFade = 1f;

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player")) {
            Player playerScript = collider.GetComponent<Player>();
            yield return playerScript.RunTeleportAnimation(timeToFade);

            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
