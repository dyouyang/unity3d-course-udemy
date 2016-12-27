using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class ScoreMasterTest {

	[Test]
	public void EditorTest()
	{
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void FailingTest() {
		Assert.AreEqual (1, 2);
	}
}
