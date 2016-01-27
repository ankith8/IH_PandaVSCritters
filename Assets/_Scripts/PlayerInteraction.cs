using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

	public int bombCount = 0;
	public int keyCount = 0;
	public int batteryCount = 0;

	Animator m_Anim;
	PlayerHealth m_playerHealth;

	public GameHUD hud;
	public GameObject timeBombPrefab;

	void Start () 
	{
		m_Anim = GetComponent<Animator>();
		m_playerHealth = GetComponent<PlayerHealth>();
		hud.UpdateBombsText(bombCount);
	}
	
	public void CollectBombs()
	{
		bombCount+=4;
		hud.UpdateBombsText(bombCount);
	}

	public void ThrowBomb()
	{
		Invoke("PlaceBomb",1);
	}
	void PlaceBomb()
	{ 
		Instantiate(timeBombPrefab,transform.position,Quaternion.identity);
		bombCount--;
		hud.UpdateBombsText(bombCount);
	}

	public void CollectHealth( int health)
	{
		m_playerHealth.AddHealth(health);
	}

	public void CollectKey()
	{
		keyCount+=1;
	}

	public void UseKey()
	{

	}

	public void CollectBattery()
	{
		batteryCount+=1;
	}

	public void UseBattery()
	{

	}

	public void Attack()
	{

	}

	public void PushObject()
	{

	}

	public void TakeDamage()
	{

	}

	public void LevelComplete()
	{
		m_Anim.SetBool("GameWon",true);
		Invoke("ShowWin",1);
	}

	public void LevelFailed()
	{
		Invoke("ShowFail",1);
	}

	void ShowWin()
	{
		hud.ShowGameWinScreen();
	}

	void ShowFail()
	{
		hud.ShowGameOverScreen();
	}

	void OnTriggerEnter(Collider other)
	{
		switch(other.tag)
		{
			case "Battery":
				CollectBattery();
				Destroy(other.gameObject);	
				AudioManager.instance.PlaySound("FoodCollect",transform.position);
				break;

			case "Key":
				CollectKey();
				Destroy(other.gameObject);
				AudioManager.instance.PlaySound("FoodCollect",transform.position);
				break;

			case "Bombs":
				//Bombs bombs = other.GetComponent<Bombs>();
				CollectBombs();
				Destroy(other.gameObject);
				AudioManager.instance.PlaySound("BombsCollect",transform.position);
				break;
			/*
			case "Bomb":
				TakeDamage();
				break;
			*/
			case "Food":
				int healthGain = (int)other.GetComponent<Food>().foodType;
				CollectHealth(healthGain);
				Destroy(other.gameObject);
				AudioManager.instance.PlaySound("FoodCollect",transform.position);
				break;

			case "Door":
				UseKey();
				break;

			case "Lazer":
				UseBattery();
				break;

			case "Doorway":
				LevelComplete();
				break;

		}
	}
}
