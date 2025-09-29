using UnityEngine;

public class RC : MonoBehaviour
{
    public void ButtonNorth()
    {
        InputBus.MoveNorth();
    }

    public void ButtonSouth()
    {
        InputBus.MoveSouth();
    }

    public void ButtonWest()
    {
        InputBus.MoveWest();
    }

    public void ButtonEast()
    {
        InputBus.MoveEast();
    }

    public void ButtonUp()
    {
        InputBus.MoveUp();
    }
    public void ButtonDown()
    {
        InputBus.MoveDown();
    }

    public void ButtonStop()
    {
        InputBus.MoveStop();
    }
}
