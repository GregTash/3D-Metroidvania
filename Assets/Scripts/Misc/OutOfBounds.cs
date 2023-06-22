using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(_playerTransform.position.y <= transform.position.y)
        {
            _playerTransform.GetComponent<PlayerManager>().health = 0;
        }
    }
}