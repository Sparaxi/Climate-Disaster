using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{

    public Transform cam;
    public Transform attackPoint;
    public GameObject Object;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpForce;

    bool ready;

    void Start()
    {
        ready= true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && ready && totalThrows > 0)
        {
            Throwing();
        }
    }

    private void Throwing()
    {
        ready = false;

        GameObject projectile = Instantiate(Object,attackPoint.position,cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);;
    }

    private void ResetThrow() 
    {
        ready = true;
    }
}
