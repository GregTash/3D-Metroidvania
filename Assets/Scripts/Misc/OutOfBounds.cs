using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    private void Update()
    {
        if(_playerTransform.position.y <= transform.position.y)
        {
            if (_playerTransform.GetComponent<PlayerManager>().respawnPoint != null)
            {
                _playerTransform.position = _playerTransform.GetComponent<PlayerManager>().respawnPoint.position;
            }
            else
            {
                _playerTransform.GetComponent<PlayerManager>().health = 0;
            }
        }
    }
}