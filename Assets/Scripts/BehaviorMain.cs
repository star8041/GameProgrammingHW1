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

        // �̵� �ӵ� ����
        rb.velocity = new Vector3(movement.normalized.x * speed, rb.velocity.y, movement.normalized.z * speed);

        // ���콺 �Է¿� ���� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // �������� ���� ���� ����
            isGrounded = false; // ���� �� ���߿� ������ ǥ��
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��(Ground) �±׿� �浹���� ���� isGrounded�� true�� ����
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ���� ������� ǥ��
        }
    }
}
