using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Baby_Dino_Ground : MonoBehaviour
{
    public bool isOnGround = true;
    public bool isOnPlatform = false;

    private float fallSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnGround && !isOnPlatform)
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
            isOnPlatform = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isOnGround = false;
        if (collision.CompareTag("Platform"))
            isOnPlatform = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
            isOnGround = true;
        if (collision.CompareTag("Platform"))
            isOnPlatform = true;
    }
}
