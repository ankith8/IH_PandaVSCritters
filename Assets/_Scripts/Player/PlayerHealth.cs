using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour,IDamagable
{
    public int startingHealth = 100;
    public int currentHealth;
   	public Slider healthSlider;
   // public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
	ThirdPersonCharacter playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
	PlayerInteraction playerInterction;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
		playerMovement = GetComponent <ThirdPersonCharacter> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
		HealthSliderStatus(currentHealth);
		//healthSlider.value = currentHealth;
		playerInterction = GetComponent <PlayerInteraction> ();
    }

	/*
    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }
	*/

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;
		HealthSliderStatus(currentHealth);
        //healthSlider.value = currentHealth;
		AudioManager.instance.PlaySound("EnemyAttack",transform.position);
        //playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
		else
		{
			anim.SetTrigger("Damage");
		}
    }

	public void AddHealth(int health)
	{
		if(startingHealth > currentHealth)
		{
			currentHealth += health;
			if(currentHealth > startingHealth)
				currentHealth = startingHealth;
		}
		//healthSlider.value = currentHealth;
		HealthSliderStatus(currentHealth);
	}

    void Death ()
    {
        isDead = true;

        //playerShooting.DisableEffects ();

        anim.SetBool ("Dead",true);
		playerInterction.LevelFailed();
     //   playerAudio.clip = deathClip;
     //   playerAudio.Play ();
		AudioManager.instance.PlaySound("PlayerDeath",transform.position);
     	   playerMovement.enabled = false;
        //playerShooting.enabled = false;
    }


	void HealthSliderStatus(int val)
	{
		healthSlider.value = val;

		if(val > 69)
		{
			healthSlider.fillRect.GetComponent<Image>().color = Color.green;
		}
		else if(val > 39 && val < 70)
		{
			healthSlider.fillRect.GetComponent<Image>().color = Color.yellow;
		}
		else if(val < 40)
		{
			healthSlider.fillRect.GetComponent<Image>().color = Color.red;
		}

	}


}
