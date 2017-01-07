using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

public class ActionMasterTest {

	[Test]
	public void FailingTest() {
		Assert.AreEqual (1, 2);
	}

	[Test]
	public void BowlStrikeReturnsEndTurn() {
		List<int> bowls = new List<int>{10};
		Assert.AreEqual (ActionMaster.Action.EndTurn, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void Bowl8OnFirstBowlReturnsTidy() {
		List<int> bowls = new List<int>{8};
		Assert.AreEqual (ActionMaster.Action.Tidy, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void BowlSpare2Then8ReturnsEndTurn() {
		List<int> bowls = new List<int>{2, 8};
		Assert.AreEqual (ActionMaster.Action.EndTurn, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void BowlStrikeOnLastFrameReturnsReset() {
		List<int> bowls = new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, 10}; // First 18 bowls, 9 frames.
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void BowlSpareOnLastFrameReturnsReset() {
		List<int> bowls = new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,8}; // First 18 bowls, 9 frames.
		Assert.AreEqual (ActionMaster.Action.Reset, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void Bowl20EndGame() {
		List<int> bowls = new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,7}; // First 18 bowls, 9 frames.
		Assert.AreEqual (ActionMaster.Action.EndGame, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void Bowl21EndGame() {
		List<int> bowls = new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,8,8}; // First 20 bowls, 10 frames.
		Assert.AreEqual (ActionMaster.Action.EndGame, ActionMaster.NextAction (bowls));
	}

	[Test]
	public void BowlStrikeOn19ThenBowl5ShouldTidy() {
		List<int> bowls = new List<int>{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,5}; // First 19 bowls.
		Assert.AreEqual (ActionMaster.Action.Tidy, ActionMaster.NextAction (bowls));
	}
}
