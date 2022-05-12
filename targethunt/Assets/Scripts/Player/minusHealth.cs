using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minusHealth : MonoBehaviour
{
    public GameObject ticketBooth;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health.Instance.TakeDamage(0.7f);
            StartCoroutine(SpawnPlayer());
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(0.2f);
        transform.position = ticketBooth.transform.position;
    }
}
