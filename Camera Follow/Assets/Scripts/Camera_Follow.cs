using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform _hero;
    [SerializeField] private float _lerpTime;
    private Vector3 _offset;
    void Start() {
        _offset = transform.position - _hero.position;
    }
    void LateUpdate()
    {
        Vector3 _newPos = Vector3.Lerp(transform.position, _offset + _hero.position, _lerpTime);
        transform.position = _newPos;
    }
}
