using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit")) {
            FindAnyObjectByType<GameManager>().increse_exes();
            
        }
    }
}
