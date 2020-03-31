using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightBalance : MonoBehaviour
{
    Transform t;
    GameObject Parent, Left, Right;
    float LeftMass, RightMass;
    string LeftObj = null, RightObj = null;
    Rigidbody rb;
    Vector3 HeavyLeft = new Vector3(0f, 0f, 10f);
    Vector3 HeavyRight = new Vector3(0f, 0f, -10f);
    Vector3 Balanced = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        LeftMass = 0;
        RightMass = 0;
        rb = null;

        Parent = this.gameObject;
        t = Parent.transform;
        Left = t.GetChild(0).gameObject;
        Right = t.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter Collision");

        Collider myCollider = collision.contacts[0].thisCollider;
        rb = collision.gameObject.GetComponent<Rigidbody>();
        if (myCollider.gameObject.CompareTag("Left"))
        {
            LeftMass = rb.mass;
            LeftObj = collision.gameObject.name;
            Debug.Log("Left " + LeftMass);
        }
        else if (myCollider.gameObject.CompareTag("Right"))
        {
            RightMass = rb.mass;
            RightObj = collision.gameObject.name;
            Debug.Log("Right " + RightMass);
        }

        if (LeftMass > RightMass)
        {
            // Parent.transform.Rotate(HeavyLeft,Space.Self);
            UnityEditor.TransformUtils.SetInspectorRotation(t, HeavyLeft);
        }
        else if (RightMass > LeftMass)
        {
            //Parent.transform.Rotate(HeavyRight, Space.Self);
            UnityEditor.TransformUtils.SetInspectorRotation(t, HeavyRight);
        }
        else
        {
            //Parent.transform.Rotate(Balanced, Space.Self);
            UnityEditor.TransformUtils.SetInspectorRotation(t, Balanced);
        }
    }

    
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit Collision");

        if (collision.transform.name==LeftObj)
        {
            LeftMass = 0;
            LeftObj = null;
            Debug.Log("Left " + LeftMass);
        }
        else if (collision.transform.name == RightObj)
        {
            RightMass = 0;
            RightObj = null;
            Debug.Log("Right " + RightMass);
        }

        if (LeftMass > RightMass)
        {
            UnityEditor.TransformUtils.SetInspectorRotation(t, HeavyLeft);
        }
        else if (RightMass > LeftMass)
        {
            UnityEditor.TransformUtils.SetInspectorRotation(t, HeavyRight);
        }
        else
        {
            UnityEditor.TransformUtils.SetInspectorRotation(t, Balanced);
        }
    }
    
}
