using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamagable
{
    public int startingHealth = 40;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();

        currentHealth = startingHealth;
    }


	/*
    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
	*/

    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

      //  enemyAudio.Play ();

        currentHealth -= amount;
            
       // hitParticles.Play();
		AudioManager.instance.PlaySound("EnemyDeath",transform.position);
        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;
		
       // anim.SetTrigger ("Dead");
		Destroy(gameObject);
		AudioManager.instance.PlaySound("EnemyDeath",transform.position);
      //  enemyAudio.clip = deathClip;
      //  enemyAudio.Play ();
    }

	/*
    public void StartSinking ()
    {
        GetComponent <NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        //ScoreManager.score += scoreValue;
        Destroy (gameObject, 2f);
    }
	*/
}
