using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum LevelNumber
	{
		Level_1,
		Level_2,
		Level_3,
		Level_4,
		Level_5
	}

	public Teleporter teleporter;

	public LevelNumber currentLevelNumber = LevelNumber.Level_1;

	// Use this for initialization
	void Start () 
	{
		if(teleporter == null)
		{
			teleporter = GameObject.FindGameObjectWithTag("Doorway").GetComponent<Teleporter>();
		}
		teleporter.ActivateForcefield();
	}
}
