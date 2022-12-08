using UnityEngine;
using TMPro;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.Configuration;
using Niantic.ARDK.Utilities;

public class ARSessionBehaviour : MonoBehaviour
{
    [SerializeField] private IARCamera _camera;
    [SerializeField] private TextMeshProUGUI PosText;
    [SerializeField] private TextMeshProUGUI RotText;
    // Update is called once per frame
    void Update()
    {
        var pos = _camera.Transform.ToPosition();
        var rot = _camera.Transform.ToRotation();

        PosText.text = $"{pos:F0}";
        RotText.text = $"{rot:F0}";
    }
}
