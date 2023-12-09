using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    GameObject _explosion;
    Animator _explosionAnimator;

    private void Update()
    {
        if (_explosion != null)
        {
            if (_explosionAnimator.GetCurrentAnimatorStateInfo(0).IsName("Ended"))
            {
                Destroy(_explosion);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _explosion = Instantiate(explosion, transform.position, Quaternion.identity);
        _explosionAnimator = _explosion.GetComponent<Animator>();

        DisableObjectAndChild(transform);

        Debug.Log(collision.transform.name);
    }

    void DisableObjectAndChild(Transform parent)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        if (parent.childCount > 0)
        {
            for (int i = 0; i < parent.childCount; i++)
            {
                if (parent.GetChild(i).GetComponent<Rigidbody>() != null) parent.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
                if (parent.GetChild(i).GetComponent<Collider>() != null) parent.GetChild(i).GetComponent<Collider>().enabled = false;
                if (parent.GetChild(i).GetComponent<MeshRenderer>() != null) parent.GetChild(i).GetComponent<MeshRenderer>().enabled = false;

                DisableObjectAndChild(parent.GetChild(i));
            }
        }
    }
}
