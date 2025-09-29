using UnityEngine;

public class Clue : MonoBehaviour
{
    private void Update()
    {
        transform.LookAt(Player.Instance.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Finger"))
        {
            Destroy(gameObject);
        }
    }
}
