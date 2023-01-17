using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkCube : MonoBehaviour
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

    void OnMouseDown()
    {
        Debug.Log(gameObject.name);
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = Waypoints[Waypoints.Length-1].transform.position;
        StartCoroutine(translateSpawnedCube(cube, 3f));
    }

    IEnumerator translateSpawnedCube(GameObject cube, float timeToMove)
    {
        for (int i = Waypoints.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                cube.SetActive(false);
                Debug.Log("Travel ends !");
            }
            else
            {
                Vector3 direction = cube.transform.position - Waypoints[i].transform.position;
                transform.Translate(direction * 1f * Time.deltaTime);
                Debug.Log("Time to move !");
            }
            yield return new WaitForSeconds(timeToMove);
        }

    }

}
