using UnityEngine;
using Cinemachine;

public class CutsceneManager : MonoBehaviour
{
    CinemachineBrain _camBrain;
    Transform _camTransform;
    Animation _cutsceneAnimation;

    void Start()
    {
        _camBrain = Camera.main.GetComponent<CinemachineBrain>();
        _camTransform = Camera.main.transform;
        _cutsceneAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            EnableCutscene();
        }
    }

    public void EnableCutscene()
    {
        _camBrain.enabled = false;

        _camTransform.position = transform.position;
        _camTransform.parent = transform;

        _cutsceneAnimation.Play();
    }

    public void DisableCutscene()
    {
        _camBrain.enabled = true;

        _camTransform.parent = null;
    }
}
