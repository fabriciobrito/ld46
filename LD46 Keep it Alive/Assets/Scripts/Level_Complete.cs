using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete : MonoBehaviour
{
    public float WaitTillLoadLevel = 2.0f;

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
        if (collision.CompareTag("BabyDino"))
        {
            GameObject message = GameObject.FindGameObjectWithTag("Finish");
            message.GetComponent<TMPro.TextMeshProUGUI>().text = "Well Done!";
            message.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }

    IEnumerator WaitAndLoadNextLevel()
    {
        yield return new WaitForSeconds(WaitTillLoadLevel);
        RestartLevel();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
