using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_Friction : MonoBehaviour
{
    [Tooltip("Multiplier of the angular velocity for the torque to apply.")]
    public float Friction = 0.4f;

    private HingeJoint2D _hinge;
    private Rigidbody2D _thisBody;
    private Rigidbody2D _connectedBody;

    // Use this for initialization
    void Start()
    {
        _hinge = GetComponent<HingeJoint2D>();
        _connectedBody = _hinge.connectedBody;

        _thisBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var angularV = _hinge.jointSpeed;
        //Debug.Log("angularV " + angularV);
        var worldTorque = Friction * angularV;

        _thisBody.AddTorque(-worldTorque);
        _connectedBody.AddTorque(worldTorque);
    }
}
