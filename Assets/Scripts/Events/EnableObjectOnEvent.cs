using UnityEngine;

public class EnableObjectOnEvent : MonoBehaviour
{
    [SerializeField] GameObject objectToEnable;

    public void EnableObject()
    {
        objectToEnable.SetActive(true);
    }
}