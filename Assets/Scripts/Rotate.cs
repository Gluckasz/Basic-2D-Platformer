using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 2;
    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0 , 360 * rotationSpeed * Time.deltaTime);
    }
}
