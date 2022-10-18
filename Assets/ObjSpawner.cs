using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    
    public List<GameObject> spawnables = new List<GameObject>();
    public void SpawnObject()
    {
        int rand = Random.Range(0, spawnables.Count);
        Instantiate(spawnables[rand], this.transform.position, transform.rotation);
    }
}
