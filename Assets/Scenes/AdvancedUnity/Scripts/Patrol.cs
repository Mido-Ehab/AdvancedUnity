using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float sphereSpeed = 5f;
    //public int cubesVisted = 0;

    private GameObject currentTarget;
    private HashSet<GameObject> visitedCubes = new HashSet<GameObject>(); // Faster lookups
    public AudioManager audioManager;

    void Update()
    {
        CheckVisitedCubes();

        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, sphereSpeed * Time.deltaTime);
        }
    }

    private void CheckVisitedCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");

       
        if (visitedCubes.Count == cubes.Length)
        {
            visitedCubes.Clear();
        }

        
        if (currentTarget == null || Vector3.Distance(transform.position, currentTarget.transform.position) <= 0f)
        {
            if (currentTarget != null)
            {
                visitedCubes.Add(currentTarget);
                //cubesVisted++;

                audioManager.PlayCubeVisitedSound();
                currentTarget = null;
            }

            currentTarget = FindNearestUnvisitedCube(cubes);
        }
    }

    private GameObject FindNearestUnvisitedCube(GameObject[] cubes)
    {
        GameObject nearestCube = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject cube in cubes)
        {
            
            if (!visitedCubes.Contains(cube))
            {
                float distance = Vector3.Distance(transform.position, cube.transform.position);

                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    nearestCube = cube;
                }
            }
        }

        return nearestCube;
    }
    public int GetVisitedCubesCount()
    {
        return visitedCubes.Count;
    }
}
