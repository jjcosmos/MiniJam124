using UnityEngine;

public class RotateBobber : MonoBehaviour
{

    private Vector3 _startPosition;
    [SerializeField] private float _bobScale = 0.2f;
    [SerializeField] private float _rotSpeed = .5f;
    
    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = _startPosition + Vector3.up * (Mathf.Sin(Time.time) * _bobScale);
        transform.localRotation = Quaternion.Euler(new Vector3(0f, Time.time * 360f * _rotSpeed % 360, 0f));
    }
}
