using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    void Awake()
    {
        // Если объект игрока уже существует — удаляем дубликат
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
