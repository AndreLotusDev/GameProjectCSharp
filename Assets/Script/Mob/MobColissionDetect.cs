using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobColissionDetect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
            
        }

    }
}
