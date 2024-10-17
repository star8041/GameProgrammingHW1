using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) { movement += transform.forward; }
        if (Input.GetKey(KeyCode.S)) { movement -= transform.forward; }
        if (Input.GetKey(KeyCode.A)) { movement -= transform.right; }
        if (Input.GetKey(KeyCode.D)) { movement += transform.right; }

        // 이동 속도 적용
        rb.velocity = new Vector3(movement.normalized.x * speed, rb.velocity.y, movement.normalized.z * speed);

        // 마우스 입력에 따른 회전 처리
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 위쪽으로 힘을 가해 점프
            isGrounded = false; // 점프 후 공중에 있음을 표시
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 땅(Ground) 태그와 충돌했을 때만 isGrounded를 true로 설정
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 땅에 닿았음을 표시
        }
    }
}
