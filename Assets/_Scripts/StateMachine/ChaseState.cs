using UnityEngine;
using System.Collections;

public class ChaseState :  IEnemyState {
		

	private readonly StatePatternEnemy enemy;
	
	public ChaseState (StatePatternEnemy statePatternEnenmy)
	{
		enemy = statePatternEnenmy;
	}

	public void UpdateState()
	{
		Look();
		Chase();
	}
	
	public void OnTriggerEnter(Collider other)
	{
		
	}
	
	public void ToPatrolState()
	{
		
	}
	
	public void ToAlertState()
	{
		enemy.currentState = enemy.alertState;
	}
	
	public void ToChaseState()
	{
		Debug.Log("Cannot transition to same state");
	}

	private void Chase()
	{
		enemy.meshRendererFlag.material.color = Color.red;
		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.Resume ();
	}

	public void ToAttackState()
	{
		enemy.currentState = enemy.attackState;
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
	
		if (Physics.Raycast (enemy.eyes.transform.position, 
		                     enemyToTarget,
		                     out hit, 
		                     enemy.sightRange)
		    && hit.collider.CompareTag ("Player")) 
		{
			enemy.chaseTarget = hit.transform;

			if (Vector3.Distance(enemy.transform.position,enemy.chaseTarget.position) < enemy.attackDistance)
			{
				ToAttackState();
			}
			
		}
		else
		{
			ToAlertState();
		}
	}
}
