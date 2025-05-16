using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] GameObject[] bullets;
    [SerializeField] Transform bulletpos;
    [SerializeField] float bulletSpeed;

    public void Fire()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeSelf)
            {
                bullets[i].SetActive(true);
                bullets[i].transform.position = bulletpos.position;
                bullets[i].GetComponent<Rigidbody>().AddForce(bulletpos.up * bulletSpeed, ForceMode.Force);
                break;
            }
        }
    }
}
