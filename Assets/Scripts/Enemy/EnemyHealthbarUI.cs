using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbarUI : MonoBehaviour
{
    [SerializeField] DamageTarget damageTarget;
    Slider _slider;

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        float sliderValue = (float)damageTarget.Health / (float)damageTarget.maxHealth;

        _slider.value = sliderValue;
    }
}
