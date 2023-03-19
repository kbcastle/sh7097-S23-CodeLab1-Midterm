using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followPosition;

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(followPosition.position.x, followPosition.position.y, -10);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
