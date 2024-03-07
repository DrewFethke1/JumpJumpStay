using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        ApplyForce(collision);
    }

    void ApplyForce(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
            if (otherRb != null)
            {
                // Calculate force direction and magnitude based on the collision contact point
                Vector3 forceDirection = transform.position - collision.contacts[0].point;
                float forceMagnitude = Mathf.Max(5f, forceDirection.magnitude);

                // Apply force to both players
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
                otherRb.AddForce(-forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            }
        }
    }
}
