using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBoost : MonoBehaviour
{
    public float boostForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {   //Add boost if it is a "car"
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
            if (carRigidbody != null)
            {
                carRigidbody.AddForce(transform.forward * boostForce, ForceMode.Impulse);
            }
        }
    }
}
