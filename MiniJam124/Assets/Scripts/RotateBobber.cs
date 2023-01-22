using UnityEngine;

public class RotateBobber : MonoBehaviour
{

    private Vector3 _startPosition;
    
    private void Start()
    {
        _startPosition = transform.localPosition;
    }

    void Update()
    {
        transform.localPosition = _startPosition + Vector3.up * (Mathf.Sin(Time.time) * 0.2f);
        transform.localRotation = Quaternion.Euler(new Vector3(0f, Time.time * 360f * .5f % 360, 0f));
    }
}
