using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{

	#region Refrences

	Text highScoreText;
	ScoreManager scoreManager;

	#endregion

		
	#region Unity callbacks
	private void Awake()
	{
		highScoreText = GetComponent<Text>();
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
	}

	private void Update()
	{
		if (ScoreManager.score >= PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore" , ScoreManager.score);
			highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
		}

		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			ResetHighScore();
		}

	}
	#endregion

	#region Private Functions

	void ResetHighScore()
	{
		PlayerPrefs.SetInt("HighScore" , 0);
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
	}

	#endregion

}
