using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text highscore;
	public Text secondsSurvivedUI;
	bool gameOver;

	void Start() {
		FindObjectOfType<PlayerController> ().OnPlayerDeath += OnGameOver;
		highscore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
	}

	void Update () {
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				SceneManager.LoadScene (3);
			}
		}
	}

	void OnGameOver() {
		gameOverScreen.SetActive (true);
		int timeSurvive = Mathf.RoundToInt(Time.timeSinceLevelLoad);
		secondsSurvivedUI.text = timeSurvive.ToString();

		if(timeSurvive > PlayerPrefs.GetInt("HighScore",0))
		{
			PlayerPrefs.SetInt("HighScore",timeSurvive);
			highscore.text = timeSurvive.ToString();
		}

		gameOver = true;
	}
}
