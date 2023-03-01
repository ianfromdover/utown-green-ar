using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Allows the sparkler to be lit and unlit, and the sparks to move down its stick
/// Lighting the sparkler is triggered by the SparkTrigger.cs class, placed on the child's collider
///
/// TODO: smoke must be visible at night
/// </summary>
public class SparklerController : MonoBehaviour
{
    [SerializeField] private float trailTime = 3.0f;
    public UnityEvent onSparklerLit;
    public UnityEvent onSparklerDied;
    
    [SerializeField] private GameObject friendTrailObj; // a particle system that emits one long trail
    
    // for moving the sparks down the stick
    [SerializeField] private Animator anim;
    public bool isLit { get; private set; }

    void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDied ??= new UnityEvent();
        isLit = true;
    }

    public void LightSparkler()
    {
        isLit = true;
        anim.Play("SparklerBurnout");
        onSparklerLit.Invoke();
    }

    /// <summary>
    /// Triggered by the animation clip event.
    /// The animation clip already enables the smoke
    /// </summary>
    public void AnimatorDied()
    {
        isLit = false;
        onSparklerDied.Invoke();
    }
    
    /// <summary>
    /// For debug use. For normal extinguishing, see AnimatorDied()
    /// </summary>
    public void ExtinguishSparkler()
    {
        isLit = false;
        anim.Play("Dead");
    }

    public void EnableTrails() { StartCoroutine(DrawTrails()); }
    public void DisableTrails() { friendTrailObj.SetActive(false); }
    private IEnumerator DrawTrails()
    {
        friendTrailObj.SetActive(true);
        yield return new WaitForSeconds(trailTime);
        DisableTrails();
    }
}