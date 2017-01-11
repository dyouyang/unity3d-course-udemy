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
				frameScores.Insert(currentFrameIndex, bowls[firstBowlIndex] + bowls[secondBowlIndex]);
			}
        }

		return frameScores;
	}
}
