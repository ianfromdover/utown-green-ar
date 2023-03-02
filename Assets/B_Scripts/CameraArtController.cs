using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens to sparkler UnityEvents to trigger animations states
/// The animator adjusts viewing fog depending on whether player's sparkler is lit
/// </summary>
public class CameraArtController : MonoBehaviour
{
    private Camera c;
    // might need a reference to post processing
    [SerializeField] private Animator anim; // increases viewing fog
    public UnityEvent onSparklerLit;
    public UnityEvent onSparklerDied;

    private void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDied ??= new UnityEvent(); 
        onSparklerLit.AddListener(FogCamera);
        onSparklerDied.AddListener(DefogCamera);
    }

    public void FogCamera()
    {
        anim.Play("state name");
    }
    public void DefogCamera()
    {
        anim.Play("disable state name");
    }
}
