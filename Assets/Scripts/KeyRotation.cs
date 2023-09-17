using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{


    [SerializeField] private float keyRotateSpeed = 1f;
    void Update()
    {
        transform.Rotate(0,360 * keyRotateSpeed * Time.deltaTime, 0);
    }
}
