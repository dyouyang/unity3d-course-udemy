using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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

	public void FillBowls(List<int> bowls) {
		for (int bowlIndex = 0; bowlIndex < bowls.Count; bowlIndex++) {
			bowlTexts [bowlIndex].text = bowls [bowlIndex].ToString ();
		}
	}

	public void FillFrames(List<int> frames) {
		for (int frameIndex = 0; frameIndex < frames.Count; frameIndex++) {
			scoreTexts [frameIndex].text = frames [frameIndex].ToString ();
		}
	}
}
