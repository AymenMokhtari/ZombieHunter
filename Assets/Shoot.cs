using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private LayerMask layerMask;
    Rigidbody rb;
    bool shooted = false;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    { Destroy(gameObject); }

    void Update () {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);
        if (Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore))
        {
            if (Input.GetMouseButtonUp(0)&&!shooted)
            {
                shooted = true;
                SphereManager.shooted = true; 
                rb.useGravity = true;
                rb.AddForce((hit.point - transform.position) * moveSpeed, ForceMode.Force);
                Destroy(gameObject, 4);
            }

        }
    }
}
