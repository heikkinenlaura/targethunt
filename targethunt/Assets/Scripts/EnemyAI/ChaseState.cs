using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IEnemyState
{
    private StatePatternEnemy enemy;
    private Vector3 forward;

    public ChaseState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }
    public void UpdateState()
    {
        Chase();
        Look();
    }
    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToAlertState()
    {
        //enemy.currentState = enemy.alertState;
    }

    public void ToChaseState()
    {
        // ollaan chase tilassa.
    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
    }
    public void ToTrackingState()
    {
        enemy.currentState = enemy.trackingState;
    }
    void Look()
    {

        Vector3 enemyToTarget = enemy.chaseTarget.position - enemy.eye.position;
        //Debug.DrawRay(enemy.eye.position, forward * enemy.sightRange);
        Debug.DrawRay(enemy.eye.position, enemyToTarget, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(enemy.eye.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            enemy.lastKnownPlayerPos = hit.transform.position;
        }
        else
        {
            enemy.lastKnownPlayerPos = enemy.chaseTarget.position;
            ToPatrolState();
        }
    }

    void Chase()
    {
        enemy.indicator.material.color = Color.red;

        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.isStopped = false;
    }

}
