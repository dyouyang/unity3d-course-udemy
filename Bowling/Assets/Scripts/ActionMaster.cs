using UnityEngine;
using System.Collections;

public class ActionMaster {

	private int bowlNumber = 1;

	public enum Action {
		Tidy,
		Reset,
		EndTurn,
		EndGame
	};

	public Action Bowl (int pins) {

		if (pins < 0 || pins > 10) {
			throw new UnityException ("Bowled invalid number of pins (less than 0 or greater than 10");
		}

		// For now, this means we bowled a strike. TODO: handle 0 then 10 spare case.
		if (pins == 10) {
			bowlNumber += 2;
			return Action.EndTurn;
		}

		// If we bowled less than 10 and are not at the end of a frame, tidy.
		if (bowlNumber % 2 != 0) { // Middle of frame
			bowlNumber += 1;
			return Action.Tidy;
		} else { // End of frame
			bowlNumber += 1;
			return Action.EndTurn;
		}

		throw new UnityException ("Did not find a matching Action to return");
	}
}
