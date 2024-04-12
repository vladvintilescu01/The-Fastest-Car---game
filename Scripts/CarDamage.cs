using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarDamage : MonoBehaviour
{
    public int maxHealth = 40;
    public int currentHealth;
    public CarControl damage_Steering;
    public CarControl damage_Brake;
    public CarControl damage_Acceleration;
    public Slider hpBar;

    void Start()
    {
        currentHealth = maxHealth;
        damage_Steering = GetComponent<CarControl>();
        damage_Brake = GetComponent<CarControl>();
        damage_Acceleration = GetComponent<CarControl>();
    }

    public void TakeDamage(int amount)
    {       // the impact on the car 
            currentHealth -= amount;
            damage_Steering.steeringAngle -= 3;
            damage_Brake.brakeTorque -= 6000;
            damage_Acceleration.accelerationSpeed -= 850;
            hpBar.value -= amount;
    }
}
