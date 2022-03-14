using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseSim : MonoBehaviour
{

    Planet[] planetArray;

    private void Awake()
    {
        planetArray = FindObjectsOfType<Planet>(); //Instantiate planet array by getting all objects with a planet script attached
        Time.fixedDeltaTime = Constants.physicsTickRate;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FixedUpdate()
    {
        //separate for loops for calling updating velocity and position as doing it in the same loop caused the physics to be a bit funky and unstable sometimes
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
