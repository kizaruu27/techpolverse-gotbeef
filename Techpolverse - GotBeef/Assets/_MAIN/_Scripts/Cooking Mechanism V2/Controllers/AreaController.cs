using UnityEngine;
using System.Collections;


public class AreaController : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _boxCollider;

    [Header("Transform")]
    [SerializeField] private RectTransform _sliderTransform;
    [SerializeField] private RectTransform _areaTransform;

    [Header("Area Width")]
    [SerializeField] private float _areaMinWidth;
    [SerializeField] private float _areaMaxWidth;

    [Header("Area Delay")]
    [SerializeField] private float _areaMinDelayTime;
    [SerializeField] private float _areaMaxDelayTime;

    private float _sliderWidth;
    private float _startWidth;
    private float _finishWidth;

    private Vector2 _colliderSize;
    private Vector2 _areaSize;
    private Vector2 _areaPos;

    private float _speedChange;


    private void Awake()
    {
        _sliderWidth = _sliderTransform.sizeDelta.x / 2;

        _startWidth = -_sliderWidth;
        _finishWidth = _sliderWidth;
    }

    private void Start()
    {
        StartCoroutine(GeneratePosition());
        StartCoroutine(GenerateSize());
    }

    private void Update()
    {
        ChangeTransform();
    }

    private IEnumerator GeneratePosition()
    {
        var delayTime = Random.Range(_areaMinDelayTime, _areaMaxDelayTime);
        var rand = Random.Range(_startWidth, _finishWidth);

        _areaPos = new Vector2(rand, transform.localPosition.y);

        yield return new WaitForSeconds(delayTime);

        StartCoroutine(GeneratePosition());

    }

    private IEnumerator GenerateSize()
    {
        var delayTime = Random.Range(_areaMinDelayTime, _areaMaxDelayTime);
        var rand = Random.Range(_areaMinWidth, _areaMaxWidth);

        _colliderSize = new Vector2(rand, 20f);
        _areaSize = new Vector2(rand, _areaTransform.sizeDelta.y);

        yield return new WaitForSeconds(delayTime);

        StartCoroutine(GenerateSize());
    }

    private void ChangeTransform()
    {
        _speedChange = Random.Range(25f, 85f);
        _areaTransform.localPosition = Vector2.MoveTowards(_areaTransform.localPosition, _areaPos, _speedChange * Time.deltaTime);
        _boxCollider.size = Vector2.Lerp(_boxCollider.size, _colliderSize, _speedChange * Time.deltaTime);
        _areaTransform.sizeDelta = Vector2.Lerp(_areaTransform.sizeDelta, _areaSize, _speedChange * Time.deltaTime);
    }
}