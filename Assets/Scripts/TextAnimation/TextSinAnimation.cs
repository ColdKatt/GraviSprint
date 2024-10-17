using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextSinAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _positionOffset;

    private TMP_Text _text;
    private Vector2 _startAnchoredPosition;

    private float _time;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _startAnchoredPosition = _text.rectTransform.anchoredPosition;
    }

    private void Update()
    {
        _text.rectTransform.anchoredPosition = new Vector2(_startAnchoredPosition.x + _positionOffset.x * Mathf.Sin(_time),
                                                           _startAnchoredPosition.y + _positionOffset.y * Mathf.Sin(_time));

        _time += Time.deltaTime;
    }
}
