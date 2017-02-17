using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameStateManager : MonoBehaviour {

    public GameObject losePanel;
    public GameObject winPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Lose() {
        losePanel.SetActive(true);
    }
    
    public void Win() {
        winPanel.SetActive(true);
    }
}
