using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour
{

    private GameObject[] Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Waypoints[1].transform.position;
        StartCoroutine(translateSpawnedCube(cube, 2f));
    }

    IEnumerator translateSpawnedCube(GameObject cube, float timeToMove)
    {
        
        for(int i = 1; i <= Waypoints.Length - 1; i++)
        {
            if( i == Waypoints.Length - 1)
            {
                cube.SetActive(false);
                Debug.Log("Travel ends !");
            }
            else
            {
                cube.transform.position = Waypoints[i].transform.position;
                yield return new WaitForSeconds(timeToMove);
                Debug.Log("Time to move !");
            }          
        }
        
        
    }
}
