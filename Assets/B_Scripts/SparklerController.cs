using System;
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

    void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDied ??= new UnityEvent(); 
        onSparklerLit.AddListener(LightSparkler);
    }

    public void LightSparkler()
    {
        anim.Play("SparklerBurnout"); // TODO: is there a play-from-start function?
        // then i dont need a dead state
        // this is causing stack overflow
        onSparklerLit.Invoke();
    }

    /// <summary>
    /// Triggered by the animation clip event.
    /// The animation clip already enables the smoke
    /// </summary>
    public void AnimatorDied()
    {
        onSparklerDied.Invoke();
    }
    
    /// <summary>
    /// For debug use. For normal extinguishing, see AnimatorDied()
    /// </summary>
    public void ExtinguishSparkler()
    {
        // anim.Play("Dead");
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