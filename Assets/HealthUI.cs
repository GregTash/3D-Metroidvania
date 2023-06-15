using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        float sliderValue = (float) playerManager.health / (float) playerManager.MaxHealth;

        _slider.value = sliderValue;
    }
}
