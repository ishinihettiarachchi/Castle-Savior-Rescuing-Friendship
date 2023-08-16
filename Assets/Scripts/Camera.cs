using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private GameObject player;
   
    
    private void Update()
    {
        transform.position = player.transform.position + new Vector3(6.8f, 2f, -33.33333f);

    }
}
