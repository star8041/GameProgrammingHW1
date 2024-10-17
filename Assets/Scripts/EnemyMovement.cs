using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 randomDirection;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(randomDirection * moveSpeed * Time.deltaTime);
        rb.velocity = randomDirection * moveSpeed;
    }
}
