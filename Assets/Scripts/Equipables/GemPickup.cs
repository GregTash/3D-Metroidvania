using UnityEngine;
using UnityEngine.SceneManagement;

public class GemPickup : MonoBehaviour
{
    AudioSource _audioSource;
    Animator _animator;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();

        if (PlayerPrefs.GetInt(transform.name) > 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if (!player) return;

        _audioSource.Play();

        player.gemsCollected++;

        PlayerPrefs.SetInt(transform.name, 0);

        GetComponent<Collider>().enabled = false;

        _animator.Play("Collect");
    }

    public void DestroyGem()
    {
        Destroy(gameObject);
    }
}
