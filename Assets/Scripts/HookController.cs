using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] private ConfigurableJoint _configurableJoint;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _tube;

    [SerializeField] private float _motorSpeed;
    [SerializeField] private float _limitZmin;
    [SerializeField] private float _limitZmax;
    [SerializeField] private float _rotationSpeed;

    private float _direction;

    private void Start()
    {
        SoftJointLimit limit = _configurableJoint.linearLimit;
        limit.limit = _limitZmax;
        _configurableJoint.linearLimit = limit;
    }

    private void FixedUpdate()
    {
        if(_direction != 0)
        {
            Vector3 position = _rigidbody.position;
            position.y += _direction * _motorSpeed * Time.fixedDeltaTime;
            position.y = Mathf.Clamp(position.y, _limitZmax, _limitZmin);
            _rigidbody.MovePosition(position);
            _tube.transform.Rotate(_direction * _rotationSpeed, 0, 0);
        }
    }

    public void MoveUp()
    {
        _direction = 1;
    }
    public void MoveDown()
    {
        _direction = -1;
    }
    public void MoveStop()
    {
        _direction = 0;
    }
}
