using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Special script for this because Level_complete is a singleton and button looses reference when new Level_Complete is destroyed to keep only one
    public void Restart()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<Level_Complete>().RestartLevel();
    }
}
