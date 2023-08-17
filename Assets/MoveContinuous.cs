using UnityEngine;

public class MoveContinuous : MonoBehaviour
{
    public bool moveEnabled;
    [SerializeField] Vector3 speed;

    void Update()
    {
        if (moveEnabled) transform.position = new Vector3(transform.position.x + speed.x * Time.deltaTime,
             transform.position.y + speed.y * Time.deltaTime, transform.position.z + speed.z * Time.deltaTime);
    }

    public void EnableMove() => moveEnabled = true;

    public void DestroyObject(GameObject obj) => Destroy(obj);
}
