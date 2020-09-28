using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject target;
    public float Speed;
    public float Distance;
    public float Border;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > Distance)
        {
            transform.position = Vector3.Lerp(
                new Vector3(
                    transform.position.x, transform.position.y, -10),
                new Vector3(
                    Mathf.Clamp( target.transform.position.x,-Border,Border), target.transform.position.y, -10),Time.deltaTime);
        }
    }
}
