using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort_Level_Initial_Mass : MonoBehaviour
{
    public GameObject initialRock;
    public GameObject[] rocks;

    public gameType levelType = gameType.Leveled_Grounds;

    public enum gameType
    {
        Leveled_Grounds,
        High_Ground,
        Low_Ground
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

        int mass_A = 1, mass_B = 1, mass_C = 1;

        switch (levelType)
        {
            case gameType.Leveled_Grounds:
                mass_A = Random.Range(1, 8);
                mass_B = sum - mass_A;
                mass_C = Random.Range(1, 8);
                break;
            case gameType.High_Ground:
                mass_A = sum + Random.Range(1, 8);
                mass_B = mass_A - sum;
                mass_C = Random.Range(1, 8);
                break;
            case gameType.Low_Ground:
                mass_A = sum + Random.Range(1, 8);
                mass_B = mass_A - sum;
                mass_C = Random.Range(1, 8);
                break;
            default:
                break;
        }

        int index = Random.Range(0, rocks.Length);

        rocks[index].GetComponent<Rock_Mass>().mass = mass_A;
        index += index == 2 ? -2 : 1;
        rocks[index].GetComponent<Rock_Mass>().mass = mass_B;
        index += index == 2 ? -2 : 1;
        rocks[index].GetComponent<Rock_Mass>().mass = mass_C;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
