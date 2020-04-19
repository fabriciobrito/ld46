using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Mass : MonoBehaviour
{
    public float mass = 1;

    public GameObject label;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().mass = mass/5;
        label.GetComponent<TMPro.TextMeshProUGUI>().text = mass.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        label.transform.position = transform.position + offset;
    }
}
