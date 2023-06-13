using UnityEngine;

public class Bomb : MonoBehaviour
{
    float autoDestroyTime = 8f;
    [SerializeField] float radiusTime = 0.5f;
    [SerializeField] GameObject explosionRadius, fuse;

    private void Update()
    {
        if(autoDestroyTime > 0)
        {
            autoDestroyTime -= Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        Explode();
    }

    void Explode()
    {
        explosionRadius.SetActive(true);

        GetComponent<MeshRenderer>().enabled = false;
        fuse.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        Invoke("DestroyBomb", radiusTime);
    }

    void DestroyBomb() => Destroy(gameObject);
}
