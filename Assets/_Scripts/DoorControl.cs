using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {

	public GameObject info;
	Animator anim;

	void Start()
	{
		info.SetActive(false);
		anim = GetComponent<Animator>();
	}

	void OpenDoor ()
	{
		anim.SetBool("OpenDoor",true);
		// Add the Animation to open door
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			PlayerInteraction playerInteraction = other.GetComponent<PlayerInteraction>();
			if(playerInteraction.keyCount > 0)
			{
				OpenDoor ();
				info.SetActive(false);
				playerInteraction.keyCount--;
			}
			else
			{
				info.SetActive(true);
			}

		}
		else
		{
			info.SetActive(false);
		}
	}

}
