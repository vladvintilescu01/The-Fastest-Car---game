using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    public int damageAmount = 10;
    //take damange
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<CarDamage>().TakeDamage(damageAmount);

    }
}