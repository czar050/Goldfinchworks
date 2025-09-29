using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _image;
    [SerializeField] private float _holdTime;
    [SerializeField] private GazAnalyzer _gazAnalyzer;

    private float _currentHoldTime;
    private bool _isOn;
    private bool _isHolding;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Finger") && !_isHolding)
        {
            _currentHoldTime += Time.deltaTime;
            _image.gameObject.SetActive(true);
            _slider.gameObject.SetActive(true);

            if (!_isOn)
            {
                _slider.value = _currentHoldTime / _holdTime;

                if (_currentHoldTime >= _holdTime)
                {
                    _gazAnalyzer.DisplayText.gameObject.SetActive(true);
                    Debug.Log(_gazAnalyzer.DisplayText.gameObject);
                    _gazAnalyzer.IsOn = true;
                    _isOn = true;
                    _isHolding = true;
                    ReleaseButton();
                }
            }
            else
            {
                _slider.value = 1 - (_currentHoldTime / _holdTime);
                _gazAnalyzer.DisplayText.gameObject.SetActive(false);

                if (_currentHoldTime >= _holdTime)
                {
                    _gazAnalyzer.IsOn = false;
                    _gazAnalyzer.DisplayText.gameObject.SetActive(false);
                    _image.gameObject.SetActive(false);
                    _isOn = false;
                    _isHolding = true;
                    ReleaseButton();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Finger"))
        {
            if (!_isOn)
            {
                _image.gameObject.SetActive(false);
            }
            _isHolding = false;
            ReleaseButton();
        }
    }

    private void ReleaseButton()
    {
        _slider.gameObject.SetActive(false);
        _slider.value = 0;
        _currentHoldTime = 0;
    }
}
