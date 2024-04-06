using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private float _seconds = 0.5f;

    private int _value = 0;

    private Coroutine _coroutine;

    private void Start()
    {
        _valueText.text = _value.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Increasing());
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }
        }
    }

    private IEnumerator Increasing()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_seconds);

        bool isExecute = true;

        while (isExecute)
        {
            yield return waitForSeconds;

            _value++;

            _valueText.text = _value.ToString();
        }
    }
}
