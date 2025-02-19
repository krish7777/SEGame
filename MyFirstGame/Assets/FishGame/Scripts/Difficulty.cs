﻿using UnityEngine;
using System.Collections;

public class Difficulty {

	static float secondsToMaxDifficulty = 60;

	public static float GetDifficultyPercent() {
		return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
	}

}
