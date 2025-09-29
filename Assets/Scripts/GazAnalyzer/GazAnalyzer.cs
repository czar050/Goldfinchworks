using TMPro;
using UnityEngine;

public class GazAnalyzer : MonoBehaviour
{
    public bool IsOn;
    public TextMeshProUGUI DisplayText;

    [SerializeField] private Transform _dangerZone;

    private void Update()
    {
        if(IsOn)
        {
            float distance = Vector3.Distance(transform.position, _dangerZone.transform.position);
            DisplayText.text = "–¿——“ŒﬂÕ»≈ " + distance.ToString("F1");
        }
    }
}
