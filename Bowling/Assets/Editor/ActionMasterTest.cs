using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {

	ActionMaster actionMaster;

	[SetUp]
	public void Setup() {
		actionMaster = new ActionMaster ();
	}

	[Test]
	public void FailingTest() {
		Assert.AreEqual (1, 2);
	}

	[Test]
	public void BowlStrikeReturnsEndTurn() {
		Assert.AreEqual (ActionMaster.Action.EndTurn, actionMaster.Bowl (10));
	}

	[Test]
	public void Bowl8OnFirstBowlReturnsTidy() {
		Assert.AreEqual (ActionMaster.Action.Tidy, actionMaster.Bowl (8));
	}

	[Test]
	public void BowlSpare2Then8ReturnsEndTurn() {
		actionMaster.Bowl (2);
		Assert.AreEqual (ActionMaster.Action.EndTurn, actionMaster.Bowl (8));
	}

	[Test]
	public void BowlStrikeOnLastFrameReturnsReset() {
		int[] bowls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}; // First 18 bowls, 9 frames.
		foreach (int bowl in bowls) {
			actionMaster.Bowl (bowl);
		}
		Assert.AreEqual (ActionMaster.Action.Reset, actionMaster.Bowl (10));
	}

	[Test]
	public void BowlSpareOnLastFrameReturnsReset() {
		int[] bowls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}; // First 18 bowls, 9 frames.
		foreach (int bowl in bowls) {
			actionMaster.Bowl (bowl);
		}
		actionMaster.Bowl (2);
		Assert.AreEqual (ActionMaster.Action.Reset, actionMaster.Bowl (8));
	}

	[Test]
	public void Bowl20EndGame() {
		int[] bowls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}; // First 18 bowls, 9 frames.
		foreach (int bowl in bowls) {
			actionMaster.Bowl (bowl);
		}
		actionMaster.Bowl (2);
		Assert.AreEqual (ActionMaster.Action.EndGame, actionMaster.Bowl (7));
	}

	[Test]
	public void Bowl21EndGame() {
		int[] bowls = {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,8}; // First 20 bowls, 10 frames.
		foreach (int bowl in bowls) {
			actionMaster.Bowl (bowl);
		}
		Assert.AreEqual (ActionMaster.Action.EndGame, actionMaster.Bowl (8));
	}
}
