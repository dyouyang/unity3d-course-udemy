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
		string formattedBowls = FormatRolls (bowls);
		for (int bowlIndex = 0; bowlIndex < formattedBowls.Length; bowlIndex++) {
			bowlTexts [bowlIndex].text = formattedBowls[bowlIndex].ToString();
		}
	}

	public void FillFrames(List<int> frames) {
		for (int frameIndex = 0; frameIndex < frames.Count; frameIndex++) {
			scoreTexts [frameIndex].text = frames [frameIndex].ToString ();
		}
	}

	public static string FormatRolls(List<int> bowls) {
		string result = "";

		for (int i = 0; i < bowls.Count; i++) {
			// We use a current box index since bowls doesn't contain any empty bowls,
			// for example on strikes.
			int currentBox = result.Length + 1;
			int currentBowl = bowls [i];

			if (currentBowl == 0) {
				result += "-";		// Empty
			} else if (currentBox % 2 == 0 && bowls [i - 1] + currentBowl == 10) {
				result += "/";		// Spare
			} else if (currentBox >= 19 && currentBowl == 10) {
				result += "X";		// Strike in last frame
			} else if (currentBowl == 10) {
				result += "X ";		// Strike anywhere else
			} else {
				result += currentBowl.ToString ();	// Normal bowl
			}
		}

		return result;
	}
}
