using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour {

	public GameObject notificationObject;
	public Text notificationText;
	public Animator notifAnimator;

	void Start()
	{
		notificationObject.SetActive(false);
	}

	public void ShowNotification(string info)
	{
		notificationObject.SetActive(true);
		notifAnimator.SetBool("showNotification",true);
		notificationText.text = info;
	}

	public void HideNotification()
	{
		notifAnimator.SetBool("showNotification",false);
	}
}
