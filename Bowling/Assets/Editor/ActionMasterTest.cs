using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ActionMasterTest {


	[Test]
	public void FailingTest() {
		Assert.AreEqual (1, 2);
	}

	[Test]
	public void BowlStrikeReturnsEndTurn() {
		ActionMaster actionMaster = new ActionMaster ();
		Assert.AreEqual (ActionMaster.Action.EndTurn, actionMaster.Bowl (10));
	}
}
