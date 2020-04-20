using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Movement : MonoBehaviour
{
    public float cloudSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        cloudSpeed *= Random.Range(0.80f, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + Time.deltaTime * cloudSpeed,
            transform.position.y,
            transform.position.z
            );

        if (transform.position.x > 12)
        {
            transform.position = new Vector3(
                -12,
                Mathf.Clamp(transform.position.y + Random.Range(-1.0f, 1.0f), 2.5f, 5.5f),
                transform.position.z
                );
            // Set new speed to cross the screen again
            cloudSpeed *= Mathf.Clamp(Random.Range(0.90f, 1.1f), 0.1f, 1.5f);
        }
    }
}
