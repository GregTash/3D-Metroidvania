using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallLogic : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsToCollideWith = new List<GameObject>();
    public float timeBeforeReset = 7.0f;
    [SerializeField] float moveSpeed = 5.0f;
    [HideInInspector] public float timeBeforeResetPlaceholder;
    [HideInInspector] public int collidedObjectsCount = 0;
    [SerializeField] TMP_Text countText;

    void Start()
    {
        timeBeforeResetPlaceholder = timeBeforeReset;

        foreach(GameObject obj in objectsToCollideWith)
        {
            WallLogicListener script = obj.AddComponent<WallLogicListener>();
            script.wallLogicSource = this;
        }
    }

    void Update()
    {
        if(countText != null) countText.text = collidedObjectsCount + "/" + objectsToCollideWith.Count;

        if(collidedObjectsCount > 0) timeBeforeResetPlaceholder -= Time.deltaTime;

        if (collidedObjectsCount >= objectsToCollideWith.Count)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
            if(countText != null) Destroy(countText.gameObject);
        }

        if (timeBeforeResetPlaceholder <= 0) ResetCollided();
    }

    void ResetCollided()
    {
        collidedObjectsCount = 0;
        timeBeforeResetPlaceholder = timeBeforeReset;

        foreach(GameObject obj in objectsToCollideWith)
        {
            obj.GetComponent<WallLogicListener>().alreadyCollided = false;
        }
    }
}