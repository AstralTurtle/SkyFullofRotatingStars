using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetSpawner : MonoBehaviour
{
    public GameObject centerPlanet;
    // add arrayList of other planets
    public List<GameObject> otherPlanets;
    // add array of spawnable planets
    public GameObject[] spawnablePlanets;
    // Start is called before the first frame update

    public float time = 0f;
    public float spawnTime = 5f;    
    void Start()
    {
        spawnablePlanets = Resources.LoadAll<GameObject>("Planets");
        spawnPlanetfirst();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > spawnTime)
        {
            time = 0f;
            spawnTime = Random.Range(1f, 15f);
            spawnPlanet();
        }
    }

    void spawnPlanet()
    {
        // spawn a planet
        GameObject newPlanet = Instantiate(spawnablePlanets[Random.Range(0, spawnablePlanets.Length)]);
        // add script to planet
        newPlanet.AddComponent<otherPlanets>();
        // set planet position to center
        newPlanet.transform.position = centerPlanet.transform.position;
        // set orbit to center or other planet
        if (Random.Range(0,2) == 0){
            newPlanet.GetComponent<otherPlanets>().orbit = centerPlanet;
        } else {
            newPlanet.GetComponent<otherPlanets>().orbit = otherPlanets[Random.Range(0, otherPlanets.Count)];
        }

        // add planet to list of other planets
        otherPlanets.Add(newPlanet);
    }

    void spawnPlanetfirst(){
        // spawn a planet
        GameObject newPlanet = Instantiate(spawnablePlanets[Random.Range(0, spawnablePlanets.Length)]);
        // add script to planet
        newPlanet.AddComponent<otherPlanets>();
        // set planet position to center
        newPlanet.transform.position = centerPlanet.transform.position;
        // set orbit to center or other planet
        newPlanet.GetComponent<otherPlanets>().orbit = centerPlanet;
        // add planet to list of other planets
        otherPlanets.Add(newPlanet);
    }
}
