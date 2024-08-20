using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mpveGround : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;
    public Transform dosPos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos.position;
        dosPos = endPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.position =   Vector2.MoveTowards(transform.position, dosPos.position, Time.deltaTime * speed);

        if(Vector2.Distance(transform.position, dosPos.position) < 0.05f)
        {
            if(dosPos == endPos) dosPos = startPos;
            else dosPos = endPos;

        }
    }
}
