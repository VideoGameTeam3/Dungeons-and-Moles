using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private Image _time;
    [SerializeField] private TextMeshProUGUI _timeText; // Use TextMeshProUGUI for TextMeshPro
    private float _currentTime;
    [SerializeField] private float _duration;

    void Start()
    {
        _currentTime = _duration;
        _timeText.text = _currentTime.ToString();
        StartCoroutine(CountdownTime());
        }

    private IEnumerator CountdownTime()
    {
        while (_currentTime > 0)
        {
            _time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timeText.text = _currentTime.ToString();
            yield return new WaitForSeconds(1f);
            _currentTime--;
        }
         _timeText.gameObject.SetActive(false);
        _time.gameObject.SetActive(false);
        yield return null;
    }
}
