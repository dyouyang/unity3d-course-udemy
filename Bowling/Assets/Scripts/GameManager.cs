﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;

	// Use this for initialization
	void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
	}

	public void Bowl (int pinFall) {
        bowls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.HandleAction(nextAction);
        ball.Reset();
    }
}
