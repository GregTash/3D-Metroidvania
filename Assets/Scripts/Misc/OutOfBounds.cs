using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    private void Update()
    {
        if(_playerTransform.position.y <= transform.position.y)
        {
            _playerTransform.GetComponent<PlayerManager>().health = 0;
        }
    }
}