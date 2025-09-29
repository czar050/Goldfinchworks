using UnityEngine;

public class CraneController : MonoBehaviour
{
    [SerializeField] private float _speedX = 1;
    [SerializeField] private float _speedY = 1;

    [SerializeField] private Transform _base;
    [SerializeField] private Transform _tube;
    [SerializeField] private HookController _hookController;

    [SerializeField] private Vector2 _limitX;
    [SerializeField] private Vector2 _limitY;

    private Vector3 direction = Vector3.zero;

    private void OnEnable()
    {
        InputBus.OnMoveNorth += () => direction = Vector3.forward * _speedX;
        InputBus.OnMoveSouth += () => direction = Vector3.forward * -_speedX;
        InputBus.OnMoveWest += () => direction = Vector3.right * _speedY;
        InputBus.OnMoveEast += () => direction = Vector3.right * -_speedY;
        InputBus.OnMoveUp += () => _hookController.MoveUp();
        InputBus.OnMoveDown += () => _hookController.MoveDown();
        InputBus.OnMoveStop += () =>
        {
            _hookController.MoveStop();
            direction = Vector3.zero;
        };
    }

    private void OnDisable()
    {
        InputBus.OnMoveNorth -= () => direction = Vector3.forward * _speedX;
        InputBus.OnMoveSouth -= () => direction = Vector3.forward * -_speedX;
        InputBus.OnMoveWest -= () => direction = Vector3.right * _speedY;
        InputBus.OnMoveEast -= () => direction = Vector3.right * -_speedY;
        InputBus.OnMoveUp -= () => _hookController.MoveUp();
        InputBus.OnMoveDown -= () => _hookController.MoveDown();
        InputBus.OnMoveStop -= () =>
        {
            _hookController.MoveStop();
            direction = Vector3.zero;
        };
    }

    private void Update()
    {
        if(direction.x != 0)
        {
            _tube.Translate(direction * Time.deltaTime, Space.Self);

            Vector3 position = _tube.localPosition;
            position.x = Mathf.Clamp(position.x, _limitX.x, _limitX.y);
            _tube.localPosition = position;
        }
        if(direction.z != 0)
        {
            _base.Translate(direction * Time.deltaTime, Space.Self);

            Vector3 position = _base.localPosition;
            position.z = Mathf.Clamp(position.z, _limitY.x, _limitY.y);
            _base.localPosition = position;
        }
    }
}
