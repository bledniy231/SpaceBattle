using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityZone : MonoBehaviour {

    public float gravity = 0.9f;

    public BlackHole blackhole;

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rbody = other.GetComponent<Rigidbody>();
        if (rbody != null)
        {
            Debug.DrawLine(this.transform.position, rbody.transform.position, Color.red);

            Vector3 direction = this.transform.position - rbody.transform.position;
            float sqrDistance = Vector3.SqrMagnitude(direction);

            Vector3 force = direction.normalized * (gravity * blackhole.size / sqrDistance);
            rbody.AddForce(force, ForceMode.Acceleration);
        }
    }

}
