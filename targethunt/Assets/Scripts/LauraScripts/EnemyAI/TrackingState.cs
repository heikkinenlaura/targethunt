using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : IEnemyState
{
    private StatePatternEnemy enemy;

    public TrackingState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    public void UpdateState()
    {
        Look();
        Track();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ToAlertState();
        }
    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }
    public void ToTrackingState()
    {
        // ollaan tracking statessa
    }
    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }
    void Look()
    {

        Vector3 enemyToTarget = enemy.chaseTarget.position - enemy.eye.position;
        Debug.DrawRay(enemy.eye.position, enemyToTarget, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(enemy.eye.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
        else
        {
            ToPatrolState();
        }
    }
    void Track()
    {
        enemy.indicator.material.color = Color.black;
        enemy.navMeshAgent.destination = enemy.lastKnownPlayerPos;
        enemy.navMeshAgent.isStopped = false;

        if(enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            ToAlertState();
        }

    }

}
