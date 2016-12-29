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
}
