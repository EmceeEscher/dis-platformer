using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityCounterPanel : MonoBehaviour {

    public static GravityCounterPanel instance;

    [SerializeField] Text counterText;

	// Use this for initialization
	void Start () {
        instance = this;
        SetCount(0);
	}

    public void SetCount(int count) {
        if (counterText == null)
        {
            Debug.Log("counterText is null");
            return;
        }
            
        Debug.Log("Incrementing text");
        counterText.text = "Gravity Toggles: " + count.ToString();
    }
}
