using System;
using UnityEngine;

public static class InputBus
{
    public static event Action OnMoveNorth;
    public static event Action OnMoveSouth;
    public static event Action OnMoveWest;
    public static event Action OnMoveEast;
    public static event Action OnMoveUp;
    public static event Action OnMoveDown;
    public static event Action OnMoveStop;

    public static void MoveNorth()
    {
        OnMoveNorth?.Invoke();
    }

    public static void MoveSouth()
    {
        OnMoveSouth?.Invoke();
    }

    public static void MoveWest()
    {
        OnMoveWest?.Invoke();
    }

    public static void MoveEast()
    {
        OnMoveEast?.Invoke();
    }

    public static void MoveUp()
    {
        OnMoveUp?.Invoke();
    }

    public static void MoveDown()
    {
        OnMoveDown?.Invoke();
    }

    public static void MoveStop()
    {
        OnMoveStop?.Invoke();
    }
}
