using UnityEngine;
using static Pillars;

public class ColorGate : MonoBehaviour
{
    [SerializeField] private PillarColors gateColor;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        SetGateColor();
    }

    private void SetGateColor()
    {
        switch (gateColor)
        {
            case PillarColors.red:
                _renderer.material.color = Color.red;
                break;

            case PillarColors.blue:
                _renderer.material.color = Color.blue;
                break;

            case PillarColors.green:
                _renderer.material.color = Color.green;
                break;

            case PillarColors.yellow:
                _renderer.material.color = Color.yellow;
                break;

            default:
                _renderer.material.color = Color.white;
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ballmanager player = other.GetComponent<Ballmanager>();

        if (player != null)
        {
            if (player.HasColor &&
                player.CurrentColor == gateColor)
            {
                Debug.Log("Doğru Renk, Gecebilirsin.");
            }
            else
            {
                Debug.Log("Yanlis Renk");
                player.ResetPlayer();
            }
        }
    }
}
