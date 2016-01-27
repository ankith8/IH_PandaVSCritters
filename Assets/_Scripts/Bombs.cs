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


	/*
	void OnTriggerEnter(Collider other)
	{

	}
	*/
}
