using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Baby_Dino_Ground : MonoBehaviour
{
    public bool isOnGround = true;
    public bool isOnPlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnGround && !isOnPlatform)
        {
            GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            if(GetComponentInParent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic)
                GetComponentInParent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
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

    private void OnBecameInvisible()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
