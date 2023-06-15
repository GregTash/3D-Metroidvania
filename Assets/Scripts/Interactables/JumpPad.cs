using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float jumpForce = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.transform.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);
        }
    }
}