using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] TargetManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            manager.UpdatePoints(points);
            gameObject.SetActive(false);
        }
    }
}
