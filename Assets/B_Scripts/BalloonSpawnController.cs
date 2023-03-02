using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens to sparkler UnityEvents to trigger animations states
/// The animator adjusts balloon falling and enablement
/// </summary>
public class BalloonSpawnController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public UnityEvent onSparklerLit;
    public UnityEvent onSparklerDied;
    // (balloons) start balloon fall sequence
        // slowly flatten
        // desaturate as lerp to 9.81
        // acceleration from negative rising then lerp to 9.81
        // turn on collider with detected ground planes
        // (event) once particles == 0, disable the balloon spawners
    private void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDied ??= new UnityEvent(); 
        onSparklerLit.AddListener(EnableBalloons);
        onSparklerDied.AddListener(DisableBalloons);
    }

    public void EnableBalloons()
    {
        anim.Play("state name");
    }
    public void DisableBalloons()
    {
        anim.Play("disable state name");
    }
}
