using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{
    /*
    public int baseHealth = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            EnemyReachedBase();
        }
    }

    private void EnemyReachedBase()
    {
        baseHealth -= 10;

        if (baseHealth <= 0)
        {
            Debug.Log("Health reduce!");
            GameManager.Instance.LoseGame();
        }
    }*/
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        Life life = other.GetComponent<Life>();
        //Debug.Log("Collided with: " + other.gameObject.name);
        //Debug.Log(life);
        if (life != null)
        {
            life.amount -= damage;
            Debug.Log("Health reduce! Health :" + life.amount);
        }
    }
}
