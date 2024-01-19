using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMove : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundObject;
    [SerializeField] private RectTransform _secondaryBackgroundObject;

    [SerializeField] private Canvas _canvas;

    private Vector3 _returnBackgroundPosition;

    private void Start()
    {
        _returnBackgroundPosition = _secondaryBackgroundObject.position;
    }

    private void FixedUpdate()
    {
        _backgroundObject.transform.Translate(Vector2.left * GameRoot.EnvironmentSpeed);
        if (_backgroundObject.transform.position.x < 0)
        {
            _backgroundObject.GetComponent<RectTransform>().position = _returnBackgroundPosition;
        }
    }
}
