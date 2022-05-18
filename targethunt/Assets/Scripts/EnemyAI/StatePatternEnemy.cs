using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatePatternEnemy : MonoBehaviour
{
    public float searchTurnSpeed;
    public float searchingDuration;
    public float sightRange;
    public Transform[] waypoints;
    public Transform eye;
    public MeshRenderer indicator;
    public Vector3 lastKnownPlayerPos;
    public Animator anim;

    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public IEnemyState currentState;
    [HideInInspector] public PatrolState patrolState;
    [HideInInspector] public AlertState alertState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public TrackingState trackingState;
    [HideInInspector] public NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    private void Awake()
    {
        patrolState = new PatrolState(this);
        alertState = new AlertState(this);
        chaseState = new ChaseState(this);
        trackingState = new TrackingState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        currentState = patrolState;

        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }
    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
}
