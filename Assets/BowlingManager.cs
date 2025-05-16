using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManager : MonoBehaviour
{
    [SerializeField] Transform[] pinos;
    [SerializeField] Transform[] postions;
    [SerializeField] Transform bowlingPostion;
    [SerializeField] Rigidbody rb;
    [SerializeField] float score;
    bool isReseting;
    
    private void ResetPositions()
    {
        score = 0f;
        for (int i = 0; i < pinos.Length; i++)
        {
            if (pinos[i].position != postions[i].position)
            {
                score++;
                pinos[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                pinos[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pinos[i].position = postions[i].position;
            }
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = bowlingPostion.position;
        isReseting = false;
        Debug.Log(score);
    }

    IEnumerator StartReset()
    {
        yield return new WaitForSeconds(4);
        ResetPositions();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Pino"))
        {
            if (!isReseting)
            {
                isReseting= true;
                StartCoroutine(StartReset());
            }
        }
    }
}
