using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TestUIGameOver : State
{
	void OnEnable()
	{
		GameManager.Instance.Incorrect();
		ChangeState("None");
	}

	void OnDisable()
	{
	}
}
