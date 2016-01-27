using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float destroyTime = 1f;


	void Start () {
		Destroy(gameObject,destroyTime);
	}

}
