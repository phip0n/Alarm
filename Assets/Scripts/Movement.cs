using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Vector3[] _wayPoints;
    [SerializeField] private float _speed = 0.005f;
    [SerializeField] private float _requiredDistance = 0.0005f;
    private int _currentPointIndex = 0;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = (_wayPoints[_currentPointIndex] - transform.position).normalized;
        _rigidbody.velocity = direction * _speed;

        if ((_wayPoints[_currentPointIndex] - transform.position).sqrMagnitude <= _requiredDistance * _requiredDistance)
        {
            _currentPointIndex = ++_currentPointIndex % _wayPoints.Length;
        }
    }
}
