using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Baby_Dino_Ground : MonoBehaviour
{
    public bool isOnGround = true;
    public bool isOnPlatform = false;

    private GameObject whichPlatform;
    private float fallSpeed = 2.0f;
    public float offsetFromPlatform = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnGround && isOnPlatform)
        {
            transform.parent.position = new Vector3(
                transform.parent.position.x,
                whichPlatform.transform.position.y + offsetFromPlatform,
                transform.parent.position.z
                );
        }
        else if (!isOnGround && !isOnPlatform)
        {
            transform.parent.position = new Vector3(
                transform.parent.position.x,
                transform.parent.position.y - Time.deltaTime * fallSpeed,
                transform.parent.position.z
                );
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isOnGround = true;
        if (collision.CompareTag("Platform"))
        {
            isOnPlatform = true;
            whichPlatform = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isOnGround = false;
        if (collision.CompareTag("Platform"))
        {
            isOnPlatform = false;
            whichPlatform = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isOnGround = true;
        if (collision.CompareTag("Platform"))
        {
            isOnPlatform = true;
            whichPlatform = collision.gameObject;
        }
    }
}
