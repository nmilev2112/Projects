using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public float speed;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private bool facingRight = true;


    void Start()
    {
        moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        }

        if (moveSpot.position.x > transform.position.x)
        {            
            if (!facingRight)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
                facingRight = true;
            }
        }
        else if (moveSpot.position.x < transform.position.x)
        {            
            if (facingRight)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);
                facingRight = false;
            }
        }
    }
}
