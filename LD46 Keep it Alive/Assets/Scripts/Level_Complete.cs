using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level_Complete : MonoBehaviour
{
    public static Level_Complete instance = null;

    public float WaitTillLoadLevel = 2.0f;

    public string[] congrats;

    public int successCount = 0;
    private bool isWaitingLevelLoad = false;

    // Make sure this script is not destroyed on level reload and keep success count
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

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
        if (collision.CompareTag("BabyDino") && !isWaitingLevelLoad)
        {
            GameObject message = GameObject.FindGameObjectWithTag("Finish");
            message.GetComponent<TMPro.TextMeshProUGUI>().text = congrats[successCount++];
            message.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }

    IEnumerator WaitAndLoadNextLevel()
    {
        isWaitingLevelLoad = true;
        yield return new WaitForSeconds(WaitTillLoadLevel);

        if (successCount < congrats.Length)
            RestartLevel();
        else
        {
            successCount = 0;
            LoadNextLevel();
        }
        isWaitingLevelLoad = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
