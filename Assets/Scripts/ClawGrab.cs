using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGrab : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.transform.parent = transform;
        other.transform.position = transform.position;
        other.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
        transform.GetChild(0).parent = null;
        gameObject.SetActive(false);
    }
}
