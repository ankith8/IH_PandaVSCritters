using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public GameObject forceField;
	BoxCollider collider;

	void Awake()
	{
		forceField.SetActive(false);
		collider = GetComponent<BoxCollider>();
		collider.enabled = false;
	}

	[ContextMenu("ActivateForcefield")]
	public void ActivateForcefield() 
	{
		forceField.SetActive(true);
		collider.enabled = true;
	}
}
