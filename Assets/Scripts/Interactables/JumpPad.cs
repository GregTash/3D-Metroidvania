using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] float jumpForce = 15f;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.transform.GetComponent<Rigidbody>();
        Animator animator = collision.transform.GetComponentInChildren<Animator>();

        if (rb != null)
        {
            if (animator != null) animator.Play("Jump");
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(jumpForce * transform.up, ForceMode.Impulse);

            _audioSource.Play();
        }
    }
}
