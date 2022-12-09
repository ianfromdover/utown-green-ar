using UnityEngine;
using TMPro;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.Configuration;
using Niantic.ARDK.Utilities;

public class ARSessionBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private TextMeshProUGUI PosText;
    [SerializeField] private TextMeshProUGUI RotText;
    // Update is called once per frame
    void Update()
    {
        var pos = _camera.position;
        var rot = _camera.rotation;

        PosText.text = $"{pos.x:F0}, {pos.y:F0}, {pos.z:F0}";
        RotText.text = $"{rot.x:F0}, {rot.y:F0}, {rot.z:F0}";
    }
}
