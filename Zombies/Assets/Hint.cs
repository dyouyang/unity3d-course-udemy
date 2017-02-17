using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour {

    MeshRenderer textRenderer;

	// Use this for initialization
	void Start () {
        textRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Tab)) {
            textRenderer.enabled = true;
        } else {
            textRenderer.enabled = false;
        }
	}
}
