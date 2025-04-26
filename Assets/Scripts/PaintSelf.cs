using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintSelf : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] bool isToy;
    [SerializeField] Transform cabina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Paint"))
        {
            for (int i = 0; i < materials.Length; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material = materials[i];
            }
            Destroy(collision.gameObject);
            if (isToy)
            {
                transform.position = cabina.position;
            }
        }
        if (collision.collider.CompareTag("OutOfBounds"))
        {
            transform.position = cabina.position;
        }
    }
}
