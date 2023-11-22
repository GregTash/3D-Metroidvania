using System.Collections;
using UnityEngine;
using Cinemachine;

public class PoisonKill : MonoBehaviour
{
    PlayerManager _player;
    [SerializeField] CinemachineFreeLook cinemachineFreeLook;
    public static bool isDead;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out PlayerManager player);

        if(player && !isDead)
        {
            _player = player;

            _player.GetComponent<PlayerMovement>().enabled = false;
            _player.transform.GetComponentsInChildren<GlidePower>()[0].enabled = false;
            _player.GetComponent<Rigidbody>().drag = 0;
            _player.GetComponent<Rigidbody>().useGravity = false;
            _player.GetComponent<Rigidbody>().velocity = new Vector3(0, -1, 0);
            cinemachineFreeLook.Follow = null;

            isDead = true;

            StartCoroutine(KillAfterSeconds());
        }
    }

    IEnumerator KillAfterSeconds()
    {
        yield return new WaitForSeconds(3);
        _player.Respawn();
        _player.GetComponent<PlayerMovement>().enabled = true;
        _player.GetComponent<Rigidbody>().useGravity = true;
        _player.transform.GetComponentsInChildren<GlidePower>()[0].enabled = true;
        cinemachineFreeLook.Follow = _player.transform;
        isDead = false;
    }
}
