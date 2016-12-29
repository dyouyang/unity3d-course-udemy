using UnityEngine;
using System.Collections;

public class ActionMaster {

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

		if (pins == 10) {
			return Action.EndTurn;
		}

		throw new UnityException ("Did not find a matching Action to return");
	}
}
