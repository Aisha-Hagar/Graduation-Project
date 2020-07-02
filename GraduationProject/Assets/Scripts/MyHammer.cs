using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHammer : MonoBehaviour
{
    private Collider HammerCollider;
    private Rigidbody HammerRigidbody;
    private Vector3 StPosVec = new Vector3(0f, 0.11f, 0.967f);
    private Vector3 DropVec = new Vector3(0f, 0.0187f, 0.967f);
    float value, fvalue;
    public PinchSlider ps;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StPosVec;
        HammerCollider = GetComponent<Collider>();
        HammerRigidbody = GetComponent<Rigidbody>();
        HammerRigidbody.useGravity = false;
        HammerCollider.enabled = false;
        HammerRigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    public void OnSliderUpdated(SliderEventData eventData)
    {
        transform.localPosition = new Vector3(StPosVec.x, (StPosVec.y + ((eventData.NewValue)) / 2), StPosVec.z);
        value = eventData.NewValue;
    }

    public void SaveValue()
    {
        fvalue = value;
        PassValue();
    }

    public void ResetValue()
    {
        fvalue = 0;
        PassValue();
    }

    public void PassValue()
    {
        VaseCollision.Value = fvalue;
        Debug.Log("Passed Value = " + fvalue);
    }

    public void DropHammer()
    {
        if (value > 0)
        {
            HammerCollider.enabled = true;
            Debug.Log("Dropping Hammer");
            transform.localPosition = DropVec;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hammer collided with " + collision.gameObject.name);
        if (collision.gameObject.name == "Plane")
        {
            Debug.Log("Hammer Dropped on plane");
            HammerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = StPosVec;
            ps.ResetValue();
            ResetValue();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Hammer Triggerred by " + collider.gameObject.name);
        if (collider.gameObject.tag == "Vase")
        {
            Debug.Log("Hammer Dropped on vase");
            PassValue();
            HammerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = StPosVec;
        }

    }

    void OnCollisionExit()
    {
        HammerCollider.enabled = false;
    }
}
