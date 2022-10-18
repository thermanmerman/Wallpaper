using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    bool following = false;
    private GameObject plat;

    void Start()
    {
        plat = GameObject.FindGameObjectWithTag("platform");
    }
    void Update()
    {
        if (following)
        {
            Vector3 pos = transform.position;
            pos.x += plat.GetComponent<MovePlatform>().moveSpeed;
            transform.position = pos;
        }

        if (!GetComponent<SpriteRenderer>().isVisible && !following)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform"))
            following = true;
        if (col.gameObject.CompareTag("square"))
            if (col.gameObject.GetComponent<Square>().following)
                following = true;
            
        
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("platform") || col.gameObject.CompareTag("square"))
            following = false;
    }
}
