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
        int currentFrameIndex = 0;
        int currentBowlIndex = 0;

        for (int i = currentBowlIndex; i < bowls.Count; i++) {

        }

		return frameScores;
	}
}
