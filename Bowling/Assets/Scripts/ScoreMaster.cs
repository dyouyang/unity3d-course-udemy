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
		//TODO: this is very basic, dont not handle spares/strikes and end of game extra frames.
		for (int currentFrameIndex = 0; currentFrameIndex < bowls.Count / 2; currentFrameIndex++) {
			int firstBowlIndex = currentFrameIndex * 2;
			int secondBowlIndex = firstBowlIndex + 1;

			if (firstBowlIndex < bowls.Count && secondBowlIndex < bowls.Count) {
				int firstBowl = bowls [firstBowlIndex];
				int secondBowl = bowls [secondBowlIndex];
				int total = firstBowl + secondBowl;
				if (firstBowl == 10) {
					// Handle strike.
					if (secondBowlIndex + 2 < bowls.Count) {
						total = total + bowls [secondBowlIndex + 1] + bowls [secondBowlIndex + 2];
						frameScores.Insert (currentFrameIndex, total);
					}
				} else if (total == 10) {
					// Handle spare.
					if (secondBowlIndex + 1 < bowls.Count) {
						total += bowls [secondBowlIndex + 1];
						frameScores.Insert (currentFrameIndex, total);
					}
				} else {
					//frameScores.Insert (currentFrameIndex, total);
					frameScores.Add (total);
				}
			}
        }

		return frameScores;
	}
}
