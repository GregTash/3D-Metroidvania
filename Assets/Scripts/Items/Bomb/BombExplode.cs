using UnityEngine;

public class BombExplode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Breakable")
        {
            Destroy(other.transform.gameObject);
        }
    }
}
