using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe_to_Go : MonoBehaviour
{
    public float speed = 4.0f;

    public bool waitingForPlatformLeveling = false;
    public float waitTime = 1.0f;
    public bool platformLeveled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        bool walk = false;

        if (collision.CompareTag("Ground"))
            walk = true;

        if (collision.CompareTag("Platform"))
        {
            if (waitingForPlatformLeveling)
            {
                return;
            }
            else
            {
                if (platformLeveled)
                    walk = true;
                else
                    StartCoroutine(WaitForPlatformLeveling());
            }
            
        }

        if (walk)
            transform.position = new Vector3(
                transform.position.x + Time.deltaTime * speed,
                transform.position.y,
                transform.position.z
            );
    }

    IEnumerator WaitForPlatformLeveling()
    {
        waitingForPlatformLeveling = true;
        yield return new WaitForSeconds(waitTime);
        platformLeveled = true;
        waitingForPlatformLeveling = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Platform"))
        {
            platformLeveled = false;
        }
    }
}
