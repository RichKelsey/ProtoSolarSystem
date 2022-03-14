using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public float mass;
    public float radius;
    public Vector3 startVelocity;
    Vector3 velocity;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        velocity = startVelocity;
    }

    public void UpdatePlanetVelocity(Planet[] planetArray, float physicsTickRate, float gravitationalConstant)
    {
        //iterate through each planet and update their velocities by applying Newtons law of universal gravitation
        foreach(var notThisPlanet in planetArray)
        {
            if (notThisPlanet != this)
            {

                Vector3 positionDifference = notThisPlanet.GetComponent<Rigidbody>().position - this.GetComponent<Rigidbody>().position;
                float squareDistance = positionDifference.sqrMagnitude;
                Vector3 forceDirection = positionDifference.normalized;
                //Equation for Newtons law of universal gravitation:
                Vector3 force = forceDirection * gravitationalConstant * mass * notThisPlanet.mass / squareDistance;
                Vector3 acceleration = force / mass;
                //technically mass in acceleration and force cancel each other out (but easier to keep straight mentally this way)
                velocity += acceleration * physicsTickRate;
            }
        }

    }

    //update the position of the planet using the velocity calculated in UpdatePlanetVelocity()
    public void UpdatePlanetPosition(float physicsTickRate)
    {

        this.GetComponent<Rigidbody>().position += velocity * physicsTickRate;

    }
}
