using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    public GameObject cube;
    public int amountOfCubes;
    public float minSizeBounds;
    public float sizeBounds;

    public int minBounds;
    public int bounds;
    
	void Start ()
    {
		for(int i = 0; i < amountOfCubes; i++)
        {
           GameObject newCube = Instantiate(cube);

            newCube.transform.localScale = new Vector3(Random.Range(minSizeBounds, sizeBounds), Random.Range(minSizeBounds, sizeBounds) * 2, Random.Range(minSizeBounds, sizeBounds));
            newCube.transform.position = new Vector3(Random.Range(minBounds, bounds), (newCube.transform.localScale.y / 2), Random.Range(minBounds, bounds));
        }
	}
}
