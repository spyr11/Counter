
using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private float _seconds = 0.5f;

    private int _value = 0;

    private Coroutine _coroutine;

    void Start()
    {
        _valueText.text = _value.ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(BeginIncrease());

                Debug.Log("Start");
            }
            else
            {
                StopCoroutine(_coroutine);
                _coroutine = null;

                Debug.Log("Stop!!!");
            }
        }
    }

    private IEnumerator BeginIncrease()
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
