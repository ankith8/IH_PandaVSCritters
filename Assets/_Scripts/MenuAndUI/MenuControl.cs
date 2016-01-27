using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControl : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject levelSelect;
	public static int max_levels = 5;
	public RectTransform levelParent;
	int currentUnlockedLevel = 1;
	// Use this for initialization
	void Start ()
	{
		currentUnlockedLevel = PlayerPrefs.GetInt("lev_unlk",1);
		for(int i = 0 ; i < 5 ; i++)
		{
			levelParent.GetChild(i).GetComponent<Button>().interactable = false;
		}

		for(int i = 0 ; i < currentUnlockedLevel ; i++)
		{
			levelParent.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}

	public void OnStartButtonClicked()
	{
		mainMenu.SetActive(false);
		levelSelect.SetActive(true);
	}

	public void OnExitButtonClicked()
	{
		Application.Quit();
	}

	public void OnLevelSelectBackClicked()
	{
		mainMenu.SetActive(true);
		levelSelect.SetActive(false);
	}

	public void OnLevel_1_Selected()
	{
		SceneManager.LoadScene("Level_1");
	}

	public void OnLevel_2_Selected()
	{
		SceneManager.LoadScene("Level_2");
	}

	public void OnLevel_3_Selected()
	{
		SceneManager.LoadScene("Level_3");
	}

	public void OnLevel_4_Selected()
	{
		SceneManager.LoadScene("Level_4");
	}

	public void OnLevel_5_Selected()
	{
		SceneManager.LoadScene("Level_5");
	}

}
