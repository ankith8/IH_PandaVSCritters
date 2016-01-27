using UnityEngine;
using System.Collections;

public class ObjectHealth : MonoBehaviour,IDamagable {

	public int startingHealth = 20;
	public int currentHealth;

	void Awake()
	{
		currentHealth = startingHealth;
	}

	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		//playerAudio.Play ();
		if(currentHealth <= 0 )
		{
			// Create a particle Explosion
			Destroy(gameObject);
		}
	}
}
