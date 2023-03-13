using UnityEngine;
using TMPro;

public class ARSessionDebugBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private TextMeshProUGUI PosText;
    [SerializeField] private TextMeshProUGUI RotText;
    // Update is called once per frame
    void Update()
    {
        var pos = _camera.position;
        var rot = _camera.rotation;

        PosText.text = $"{pos.x:F2}, {pos.y:F2}, {pos.z:F2}";
        RotText.text = $"{rot.x:F2}, {rot.y:F2}, {rot.z:F2}";
    }
}
