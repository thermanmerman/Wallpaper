using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Drawing : MonoBehaviour
{
    public GameObject brush;
    public GameObject thing;
    public GameObject platform;
    public GameObject edgeCol;
    GameObject spawned = null;
    EdgeCollider2D edgeInstance;

    
    void Update()
    {
        
        
        Vector3 objPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, platform.transform.position.z);
        thing.transform.position = objPos;
        if (Input.GetMouseButtonDown(0))
        {
            spawned = Instantiate(brush, objPos, brush.transform.rotation);
            spawned.transform.SetParent(thing.transform);
            spawned.transform.localPosition = Vector3.zero;
            //edgeInstance = Instantiate(edgeCol, objPos, edgeCol.transform.rotation).GetComponent<EdgeCollider2D>();
            //spawned.AddComponent<EdgeCollider2D>();
            GameObject colliderGameObject = new GameObject("TrailCollider", typeof(EdgeCollider2D));
            colliderGameObject.tag = "square";
            edgeInstance = colliderGameObject.GetComponent<EdgeCollider2D>();
            
        } 
        if (spawned != null)
        {
            Debug.Log("bruh");
            SetColliderPointsFromTrail(spawned.GetComponent<TrailRenderer>(), edgeInstance);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("square");
            foreach(GameObject obj in objs)
            {
                obj.transform.SetParent(null);
            }
        }
    }

    public void ClearDrawings()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("square");
        foreach(GameObject obj in objs)
        {
            Destroy(obj);
        }
        
    }

    
    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        //avoid having default points at (-.5,0),(.5,0)
        if(trail.positionCount == 0)
        {
            points.Add(trail.transform.position);
            points.Add(trail.transform.position);
        }
        else for(int position = 0; position<trail.positionCount; position++)
        {
            //ignores z axis when translating vector3 to vector2
            points.Add(trail.GetPosition(position));
        }
        collider.SetPoints(points);
    }

}
