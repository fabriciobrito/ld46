using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Summon : MonoBehaviour
{
    public bool randomRotation = false;
    private Vector3 origPos;
    private Quaternion origRot;

    // Start is called before the first frame update
    void Start()
    {
        if(randomRotation)
            transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));

        origPos = transform.position;
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -12)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            transform.position = origPos;
            transform.Rotate(Vector3.forward, Random.Range(0, 360.0f));
        }
    }
}
