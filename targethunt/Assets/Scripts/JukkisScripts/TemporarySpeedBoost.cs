using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TemporarySpeedBoost : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    [Header("Player movement Settings")]
    [SerializeField] private float steadySpeed = 5.0f;

    [Space(10)]
    [SerializeField] private float boostIncrease = 5.0f;
    [SerializeField] private float boostTime = 10.0f;

    private bool isBoostActivated = false;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rb.mass = 10;
            if (isBoostActivated)
            {
                rb.velocity = transform.forward * (steadySpeed + boostIncrease);
            }
            else
            {
                rb.velocity = transform.forward * steadySpeed;
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            if (!isBoostActivated)
            {
                Debug.Log("Boosting player speed");
                isBoostActivated = true;
                Invoke("EndBoost", boostTime);
            }
        }
        Debug.Log(rb.velocity);
    }

    private void EndBoost()
    {
        isBoostActivated = false;
    }
}