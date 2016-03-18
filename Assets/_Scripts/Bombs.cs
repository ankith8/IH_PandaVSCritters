using UnityEngine;
using System.Collections;

public class Bombs : MonoBehaviour {

	public enum BombsType
	{
		TimeBombGroup,
		BouncersGroup,
		RemoteBombGroup
	}

	public BombsType bombsType = BombsType.TimeBombGroup;

	public int bombCount = 4;

	/*
	void OnTriggerEnter(Collider other)
	{

	}
	*/
}
