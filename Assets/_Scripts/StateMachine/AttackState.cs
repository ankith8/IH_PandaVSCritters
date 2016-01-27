using UnityEngine;
using System.Collections;

public class AttackState : IEnemyState {

	private readonly StatePatternEnemy enemy;



	public AttackState (StatePatternEnemy statePatternEnenmy)
	{
		enemy = statePatternEnenmy;
	}
	
	public void UpdateState()
	{
		Look();
		Attack();
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
		enemy.currentState = enemy.chaseState;
	}

	public void ToAttackState()
	{
		Debug.Log("Cannot transition to same state");
	}
	
	private void Chase()
	{

		enemy.navMeshAgent.destination = enemy.chaseTarget.position;
		enemy.navMeshAgent.Resume ();
	}
	private void Attack()
	{
		enemy.meshRendererFlag.material.color = Color.blue;
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
			if (Vector3.Distance(enemy.transform.position,enemy.chaseTarget.position) < enemy.attackDistance)
			{
				Attack();
			}
			else
			{
				ToChaseState();
			}
		}
	}
}
