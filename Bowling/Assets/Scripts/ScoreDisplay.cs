﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] bowlTexts;
	public Text[] scoreTexts;

	// Use this for initialization
	void Start () {
		foreach (Text bowl in bowlTexts) {
			bowl.text = "";
		}
		foreach (Text score in scoreTexts) {
			score.text = "";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}