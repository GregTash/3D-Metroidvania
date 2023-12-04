using UnityEngine;
using UnityEngine.UI;

public class FlyingBarUI : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    GlidePower _glidePower;
    Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _glidePower = gameObject.GetComponentInParent<GlidePower>();
    }

    void Update()
    {
        float sliderValue = _glidePower.GlidingStamina / _glidePower.MaxGlidingStamina;

        _slider.value = sliderValue;

        if(_glidePower.GlidingStamina >= _glidePower.MaxGlidingStamina)
        {
            _canvas.enabled = false;
        } else
        {
            _canvas.enabled = true;
        }
    }
}
