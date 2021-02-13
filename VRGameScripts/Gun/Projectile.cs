using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5.0f;

    private Rigidbody rigidbody = null;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        SetInnactive();
    }

    private void OnCollisionEnter(Collision collision)
    {
        SetInnactive();
    }

    public void Launch(Shooting shooting)
    {
        transform.position = shooting.barrel.position;
        transform.rotation = shooting.barrel.rotation;

        gameObject.SetActive(true);

        rigidbody.AddRelativeForce(Vector3.forward * 30, ForceMode.Impulse);
        StartCoroutine(TrackLifetime());
    }

    private IEnumerator TrackLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        SetInnactive();
    }

    public void SetInnactive()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        gameObject.SetActive(false);
    }
}
