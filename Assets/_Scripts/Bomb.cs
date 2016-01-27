using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public enum BombType
	{
		TimeBomb,
		Bouncers,
		RemoteBomb
	}
	public int damageAmount = 40;
	public ParticleSystem burstEffect;

	public BombType bombType = BombType.TimeBomb;

	void Start()
	{
		Invoke("Detonate",3);
		AudioManager.instance.PlaySound("BombArm",transform.position);
	}

	public void SetBombType(BombType type)
	{
		bombType = type;
	}

	public void Detonate()
	{
		Collider[] initialCollisions;
		initialCollisions = Physics.OverlapSphere(transform.position,1.5f);

		foreach(Collider col in initialCollisions)
		{

			IDamagable damagableObj = col.GetComponent<IDamagable>();
			if(damagableObj != null)
			{
				damagableObj.TakeDamage(damageAmount);
			}
		}
		ParticleSystem go = Instantiate(burstEffect,transform.position,Quaternion.identity) as ParticleSystem;
		go.Play();
		Destroy(gameObject);
		AudioManager.instance.PlaySound("BombExplode",transform.position);
		// Add a paertivle effect heres
	}



}
