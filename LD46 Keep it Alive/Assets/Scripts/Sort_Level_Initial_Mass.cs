using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Level_Initial_Mass : MonoBehaviour
{
    public GameObject initialRock;
    public GameObject[] rocks;
    public int numRocks = 3;

    public gameType levelType = gameType.Leveled;

    public enum gameType
    {
        Leveled,
        Higher,
        Ascending
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Code in Awake instead of start to prevent from being overwritten by the rock start process
    private void Awake()
    {
        int sum = Random.Range(8, 15);
        initialRock.GetComponent<Rock_Mass>().mass = (float)sum;

        GameObject manager = GameObject.FindGameObjectWithTag("Manager").gameObject;
        int level = manager.GetComponent<Level_Complete>().level;
        if (level > 9)
            numRocks = 4;
        if (level > 18)
            numRocks = 5;

        int mass_A = 1, mass_B = 1, mass_C = 1, mass_D = 1, mass_E = 1;

        switch (levelType)
        {
            case gameType.Leveled:
                mass_A = Random.Range(1, 8);
                mass_B = sum - mass_A;
                mass_C = Random.Range(1, 8);
                mass_D = Random.Range(1, 8);
                mass_E = Random.Range(1, 8);
                break;
            case gameType.Higher:
                mass_A = sum + Random.Range(1, 8);
                mass_B = mass_A - sum;
                mass_C = Random.Range(1, 8);
                mass_D = Random.Range(1, 8);
                mass_E = Random.Range(1, 8);
                break;
            case gameType.Ascending:
                mass_A = sum + Random.Range(1, 8);
                mass_B = mass_A - sum;
                mass_C = Random.Range(8, 15);
                mass_D = Random.Range(8, 15);
                mass_E = Random.Range(8, 15);
                break;
            default:
                break;
        }

        int index = Random.Range(0, numRocks);

        rocks[index].GetComponent<Rock_Mass>().mass = mass_A;
        index += index == (numRocks - 1) ? -(numRocks - 1) : 1;
        rocks[index].GetComponent<Rock_Mass>().mass = mass_B;
        index += index == (numRocks - 1) ? -(numRocks - 1) : 1;
        rocks[index].GetComponent<Rock_Mass>().mass = mass_C;
        if (numRocks >= 4)
        {
            index += index == (numRocks - 1) ? -(numRocks - 1) : 1;
            rocks[index].GetComponent<Rock_Mass>().mass = mass_D;
        }
        if (numRocks >= 5)
        {
            index += index == (numRocks - 1) ? -(numRocks - 1) : 1;
            rocks[index].GetComponent<Rock_Mass>().mass = mass_E;
        }

        float gapBetweenRocks = 9 / (numRocks - 1);
        for (int i = 0; i < numRocks; i++)
        {
            rocks[i].transform.position = new Vector3(
                -4 + gapBetweenRocks*i,
                rocks[i].transform.position.y,
                rocks[i].transform.position.z
                );
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
