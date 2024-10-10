using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }

        float mouseX = Input.GetAxis("Mouse X");
        //float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(0, mouseX * rotationSpeed * Time.deltaTime, 0);
        //transform.Rotate(-mouseY * rotationSpeed * Time.deltaTime, 0, 0);
    }
}
