using UnityEngine;
using System.Collections;

public class InfoProvider : MonoBehaviour {

	public string info = "Type your text here";
	public NotificationManager nm;
	void Start()
	{
		if(nm == null)
		{
			nm = FindObjectOfType<NotificationManager>();
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			nm.ShowNotification(info);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Player")
		{
			nm.HideNotification();
		}
	}

}
