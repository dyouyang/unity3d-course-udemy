using UnityEngine;
using System.Collections.Generic;

public class ActionMaster {

	private int bowlNumber = 1;
	private int[] bowls = new int[21];

	public enum Action {
		Tidy,
		Reset,
		EndTurn,
		EndGame
	};

	public static Action NextAction(List<int> pinFalls) {

		ActionMaster actionMaster = new ActionMaster ();
		Action currentAction = new Action ();
		foreach (int pinFall in pinFalls) {
			currentAction = actionMaster.Bowl (pinFall);
		}
		return currentAction;
	}

	private Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Bowled invalid number of pins (less than 0 or greater than 10");
		}

		bowls [bowlNumber - 1] = pins;

		// Definitely end the game.
		if (bowlNumber == 21) {
			return Action.EndGame;
		}

		// Extra bowl in case of strike on 19 or spare on 20.
		if (bowlNumber >= 19 && Bowl21Awarded ()) {
			bowlNumber += 1;
			return Action.Reset;
		} else if (bowlNumber == 20 && !Bowl21Awarded ()) {
			// No extra bowl.
			return Action.EndGame;
		}

		if (bowlNumber % 2 != 0) { // First bowl of frame.
			if (pins == 10) {
				// Strike.
				bowlNumber += 2;
				return Action.EndTurn;
			} else {
				// Also handles 0-10 spares.
				bowlNumber += 1;
				return Action.Tidy;
			}
		} else { // Second bowl of frame.
			bowlNumber += 1;
			return Action.EndTurn;
		}
	}

	private bool Bowl21Awarded() {
		if (bowls [19 - 1] + bowls [20 - 1] == 10) {
			// If we bowled a strike on 19, or we bowled a spare on 20...
			return true;
		} else {
			return false;
		}
	}
}
