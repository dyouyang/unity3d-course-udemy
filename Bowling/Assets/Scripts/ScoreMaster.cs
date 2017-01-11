using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster {

    public static List<int> ScoreCumulative (List<int> bowls) {
        List<int> cumulativeScores = new List<int>();
        List<int> frameScores = ScoreFrames(bowls);
        int totalSoFar = 0;
        foreach (int frameScore in frameScores) {
            totalSoFar += frameScore;
            cumulativeScores.Add(totalSoFar);
        }
        return cumulativeScores;
    }

	public static List<int> ScoreFrames(List<int> bowls) {
		List<int> frameScores = new List<int> ();

		int currentBowlIndex = 0;

		// Loop through bowls calculating known scores and incrementing to the
		// next start of frame. Additionally, due to the extra bowl, stop calculation
		// at the 10th frame.
		while (currentBowlIndex < bowls.Count && frameScores.Count < 10) {
			int total = bowls [currentBowlIndex];
			if (total == 10) {
				// Handle a strike.
				if (currentBowlIndex + 2 < bowls.Count) {
					total += bowls [currentBowlIndex + 1] + bowls [currentBowlIndex + 2];
					frameScores.Add (total);
				}
				// The next bowl starts the next frame.
				currentBowlIndex++;
			} else {
				int secondBowlIndex = currentBowlIndex + 1;

				// Handle a two bowl frame.
				if (secondBowlIndex < bowls.Count) {
					total += bowls [secondBowlIndex];
					if (total == 10) {
						// Handle a spare.
						if (secondBowlIndex + 1 < bowls.Count) {
							total += bowls [secondBowlIndex + 1];
							frameScores.Add (total);
						}
					} else {
						// Normal frame.
						frameScores.Add (total);
					}
				}

				// The next frame starts after the second bowl of this frame.
				currentBowlIndex += 2;
			}
		}
		return frameScores;
	}
}
