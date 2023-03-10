using UnityEngine;

/// <summary>
/// Destroys the single balloon that appears immediately when the screen is tapped.
/// That single balloon has a UI function. It gives feedback to the user that their
/// screen tap is registered.
/// </summary>
public class BalloonInitialIndicator : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10.0f;
    void Start() { Destroy(gameObject, lifeTime); }
}