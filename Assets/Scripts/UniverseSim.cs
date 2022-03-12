using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseSim : MonoBehaviour
{

    Planet[] planetArray;

    private void Awake()
    {
        planetArray = FindObjectsOfType<Planet>();
        Time.fixedDeltaTime = Constants.physicsTickRate;
    }

    private void FixedUpdate()
    {
        //separate for loops for updating velocity and position as doing it in the same loop caused the physics to be a bit funky and unstable
        for (int i = 0; i < planetArray.Length; i++)
        {
            planetArray[i].UpdatePlanetVelocity(planetArray, Constants.physicsTickRate, Constants.gravitationalConstant);
        }

        for (int i = 0; i < planetArray.Length; i++)
        {
            planetArray[i].UpdatePlanetPosition(Constants.physicsTickRate);
        }
    }
}
