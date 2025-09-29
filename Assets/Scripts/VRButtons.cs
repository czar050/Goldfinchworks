using UnityEngine;

public class VRButtons : MonoBehaviour
{
    public enum Button { North, South, West, East, Up, Down }

    [SerializeField] private Button button;
    [SerializeField] private Light _light;
    [SerializeField] private Color _green = Color.green;
    [SerializeField] private Color _red = Color.red;
    [SerializeField] private AudioSource _audioSource;

    private bool _isPressed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finger"))
        {
            _isPressed = true;

            _light.color = _red;

            _audioSource.Play();

            switch(button)
            {
                case Button.North: InputBus.MoveNorth();
                    break;

                case Button.South: InputBus.MoveSouth();
                    break;

                case Button.West: InputBus.MoveWest();
                    break;

                case Button.East: InputBus.MoveEast();
                    break;

                case Button.Up: InputBus.MoveUp();
                    break;

                case Button.Down: InputBus.MoveDown();
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Finger"))
        {
            _isPressed = false;
            _light.color = _green;
            _audioSource.Stop();
            InputBus.MoveStop();
        }
    }
}
