using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate_Mass : MonoBehaviour
{
    public float totalMass = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Rock"))
            if (collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                totalMass += collision.gameObject.GetComponent<Rigidbody2D>().mass * 5;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock"))
            if (collision.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                totalMass -= collision.gameObject.GetComponent<Rigidbody2D>().mass * 5;
    }
}
