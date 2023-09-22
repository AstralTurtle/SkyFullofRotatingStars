using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherPlanets : MonoBehaviour

{
    public GameObject orbit;
    public Vector3 direction;
    public float speed = 20f;
    // Start is called before the first frame update
    void Awake(){
        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f,1f), Random.Range(-1f, 1f));
        speed = Random.Range(10f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(orbit.transform.position, direction, speed * Time.deltaTime);
        
    }
}
