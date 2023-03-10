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
    [Header("Parameters")]
    [SerializeField] private float trailTime = 3.0f;
    
    [Header("References")]
    [SerializeField] private Animator anim; // for moving the sparks down the stick
    [SerializeField] private GameObject friendTrailObj; // a particle system that emits one long trail
    // [SerializeField] private AudioSource trailSoundLoop; // bling sound when 'frenzy trail mode'
    [SerializeField] private AudioSource fizzLoop;
    
    [Header("Events")]
    public UnityEvent onSparklerLit;
    public UnityEvent onSparklerDied;
    public bool isLit { get; private set; }

    void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDied ??= new UnityEvent();
        isLit = true;
        fizzLoop.Play();
    }

    public void LightSparkler()
    {
        isLit = true;
        fizzLoop.Play();
        anim.Play("SparklerBurnout", -1, 0f); // play from the start
        onSparklerLit.Invoke();
    }

    /// <summary>
    /// Triggered by the animation clip event.
    /// The animation clip already enables the smoke
    /// </summary>
    public void AnimatorDied()
    {
        isLit = false;
        fizzLoop.Stop();
        onSparklerDied.Invoke();
    }
    
    /// <summary>
    /// For debug use. For normal extinguishing, see AnimatorDied()
    /// </summary>
    public void ExtinguishSparkler()
    {
        isLit = false;
        fizzLoop.Stop();
        anim.Play("Dead");
    }

    public void EnableTrails()
    {
        // trailSoundLoop.Play();
        StartCoroutine(DrawTrails());
    }

    public void DisableTrails()
    {
        // trailSoundLoop.Stop();
        friendTrailObj.SetActive(false);
    }
    private IEnumerator DrawTrails()
    {
        friendTrailObj.SetActive(true);
        yield return new WaitForSeconds(trailTime);
        
        DisableTrails();
    }
}