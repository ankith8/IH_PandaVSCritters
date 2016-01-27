using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour {

	public GameObject pauseScreen;
	public GameObject gameOverScreen;
	public GameObject gameWinScreen;
	public GameObject hud;
	public Text bombsText;


	void Start () {

	}

	public void UpdateBombsText(int val)
	{
		bombsText.text = "Bombs : "+val;
	}
	
	public void OnPauseButtonClicked()
	{
		pauseScreen.SetActive(true);
		gameOverScreen.SetActive(false);
		gameWinScreen.SetActive(false);
		hud.SetActive(false);
		Time.timeScale = 0;
	}

	public void OnResumeButtonClicked()
	{
		pauseScreen.SetActive(false);
		gameOverScreen.SetActive(false);
		gameWinScreen.SetActive(false);
		hud.SetActive(true);
		Time.timeScale = 1;
	}

	public void OnExitButtonClicked()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Menu");
	}

	public void OnRestartButtonClicked()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene ().name);
	}

	public void OnNextLevelClicked()
	{
		Time.timeScale = 1;
		switch(SceneManager.GetActiveScene ().name)
		{
		case "Level_1":
			SceneManager.LoadScene("Level_2");
			break;
		case "Level_2":
			SceneManager.LoadScene("Level_3");
			break;
		case "Level_3":
			SceneManager.LoadScene("Level_4");
			break;
		case "Level_4":
			SceneManager.LoadScene("Level_5");
			break;
		case "Level_5":
			SceneManager.LoadScene("Menu");
			break;
		}
	}

	public void ShowGameWinScreen()
	{
		gameWinScreen.SetActive(true);
		pauseScreen.SetActive(false);
		gameOverScreen.SetActive(false);
		hud.SetActive(false);
		Time.timeScale = 0;

		switch(SceneManager.GetActiveScene ().name)
		{
		case "Level_1":
			PlayerPrefs.SetInt("lev_unlk",2);
			break;
		case "Level_2":
			PlayerPrefs.SetInt("lev_unlk",3);
			break;
		case "Level_3":
			PlayerPrefs.SetInt("lev_unlk",4);
			break;
		case "Level_4":
			PlayerPrefs.SetInt("lev_unlk",5);
			break;
		case "Level_5":
			PlayerPrefs.SetInt("lev_unlk",5);
			break;
		}
		PlayerPrefs.Save();
	}

	public void ShowGameOverScreen()
	{
		gameOverScreen.SetActive(true);
		pauseScreen.SetActive(false);
		gameWinScreen.SetActive(false);
		hud.SetActive(false);
		Time.timeScale = 0;
	}
}
