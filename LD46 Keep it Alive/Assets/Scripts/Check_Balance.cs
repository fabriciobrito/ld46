using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_Balance : MonoBehaviour
{
    public bool balanced = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject balance = GetComponent<HingeJoint2D>().connectedBody.gameObject;
        HingeJoint2D[] joints = balance.GetComponents<HingeJoint2D>();

        GameObject platf_A = joints[0].connectedBody.gameObject;
        GameObject platf_B = joints[1].connectedBody.gameObject;

        if (
            platf_A.GetComponent<Calculate_Mass>().totalMass ==
            platf_B.GetComponent<Calculate_Mass>().totalMass)
            balanced = true;
        else
            balanced = false;

        HingeJoint2D joint = GetComponent<HingeJoint2D>();
        if (balanced)
        {
            joint.useMotor = true;
            JointMotor2D motorRef = joint.motor;
            motorRef.motorSpeed = -joint.jointAngle;
            joint.motor = motorRef;
        }else
            joint.useMotor = false;
    }
}
