using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapController : MonoBehaviour
{
    public float rad;
    public LayerMask layerM;

    void Start()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, rad, layerM);

        foreach (Collider col in colls)
        {
            Destroy(col.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
