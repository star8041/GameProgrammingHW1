using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject shootPoint;
    public float destroyDelay;
    private GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = prefab1;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject prefab = prefab1;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (prefab == prefab1)
            {
                prefab = prefab2;
            }
            else
            {
                prefab = prefab1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            Destroy(clone, destroyDelay);
        }
    }
}