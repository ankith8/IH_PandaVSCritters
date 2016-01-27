using UnityEngine;
using System.Collections;

public class TeleporterEffect : MonoBehaviour {

	Renderer ren;
	// Use this for initialization
	void Start () 
	{
		ren = GetComponent<Renderer>();
	}

	void Update()
	{
		ren.material.mainTextureOffset = new Vector2(0, Time.time);

	}
}
