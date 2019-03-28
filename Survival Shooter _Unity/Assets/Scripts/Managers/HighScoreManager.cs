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
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HigScore").ToString();
	}

	private void Update()
	{
		if (ScoreManager.score >= PlayerPrefs.GetInt("HighSCore"))
		{
			PlayerPrefs.SetInt("HighScore" , ScoreManager.score);
			highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
		}
	}
	#endregion

}
