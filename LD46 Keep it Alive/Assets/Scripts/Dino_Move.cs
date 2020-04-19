using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino_Move : MonoBehaviour
{
    public float velocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1.0f;
            GetComponent<SpriteRenderer>().flipX = true;
        }
            
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1.0f;
            GetComponent<SpriteRenderer>().flipX = false;
        }   

        transform.position = new Vector3(
            transform.position.x + Time.deltaTime * direction * velocity,
            transform.position.y,
            transform.position.z);
    }
}
