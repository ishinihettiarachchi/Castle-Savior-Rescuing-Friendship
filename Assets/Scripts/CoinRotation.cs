using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotation : MonoBehaviour
{


    [SerializeField] private float rotateSpeed = 1f;
    void Update()
    {
        transform.Rotate( 0, 0 , 360 * rotateSpeed * Time.deltaTime);
    }
}
