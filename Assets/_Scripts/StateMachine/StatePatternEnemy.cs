using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour {

	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public float attackDistance = 1.7f;
	public Transform[] wayPoints;
	public Transform eyes;
	public Vector3 offset = new Vector3(0,.5f,0);
	public MeshRenderer meshRendererFlag;

	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public ChaseState chaseState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public AttackState attackState;
	[HideInInspector] public NavMeshAgent navMeshAgent;

	void Awake()
	{
		chaseState = new ChaseState(this);
		alertState = new AlertState(this);
		patrolState = new PatrolState(this);
		attackState = new AttackState(this);

		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void Start () 
	{
		currentState = patrolState;
	}

	void Update ()
	{
		currentState.UpdateState();
	}

	bool attacking = false;

	private void OnTriggerEnter(Collider other)
	{
//		if(other.tag == "Player")
//		{
//			if(Vector3.Distance(transform.position,other.transform.position) < 1)
//			{
//				if(!attacking)
//				{
//					attacking = true;
//					other.GetComponent<IDamagable>().TakeDamage(20);
//					Invoke ("ResetAttack",.5f);
//				}
//			}
//		}
		currentState.OnTriggerEnter(other);
	}

	private void OnTriggerStay(Collider other)
	{
		if(other.tag == "Player")
		{
			if(Vector3.Distance(transform.position,other.transform.position) < .8f)
			{
				if(!attacking)
				{
					attacking = true;
					other.GetComponent<IDamagable>().TakeDamage(20);
					Invoke ("ResetAttack",2f);
				}
			}
		}
	}

	void ResetAttack()
	{
		attacking = false;
	}
}
