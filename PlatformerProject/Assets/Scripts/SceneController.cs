using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour {

    public Image fadeoutImage;
    public float fadeinTime = 1f;

    // Use this for initialization
    void Start () {
        // fadeoutImage starts out invisible (so we can see the scene in the 
        // editor while working), immediately turns to opaque black on scene
        // load, then fades in to invisible again
        Color opaque = fadeoutImage.color;
        opaque.a = 1f;
        fadeoutImage.color = opaque;
        fadeoutImage.CrossFadeAlpha(0f, fadeinTime, false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            StartCoroutine(ReloadLevel());
        }
    }

    IEnumerator ReloadLevel() {
        fadeoutImage.CrossFadeAlpha(1f, fadeinTime, false);
        yield return new WaitForSeconds(fadeinTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
