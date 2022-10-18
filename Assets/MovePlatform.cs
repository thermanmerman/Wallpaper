using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Camera cam;
    public float moveSpeed;

    void Update()
    {
        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        if (transform.position.x >= horzExtent)
            moveSpeed *= -1;
        if (transform.position.x <= -horzExtent)
            moveSpeed *= -1;

        Vector3 pos = transform.position;
        pos.x += moveSpeed;
        transform.position = pos; 
    }
}
