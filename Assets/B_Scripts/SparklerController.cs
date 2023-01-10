using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Allows the sparkler to be lit and unlit, and the sparks to move down its stick
/// </summary>
public class SparklerController : MonoBehaviour
{
    [SerializeField] private float trailTime = 3.0f;
    public UnityEvent onSparklerLit;
    public UnityEvent onSparklerDeath;
    
    [SerializeField] private GameObject sparkObj;
    [SerializeField] private GameObject friendTrailObj; // a particlesystem that emits one long trail
    [SerializeField] private GameObject smokeObj; // a particlesystem that emits one long trail
    [SerializeField] private ParticleSystem mainSparks;
    [SerializeField] private ParticleSystem innerSparks;
    
    // for moving the sparks down the stick
    [SerializeField] private Transform sparkStartPos;
    [SerializeField] private Transform sparkEndPos;
    [SerializeField] private float positionSpeedMultiplier = 1;
    [SerializeField] private float positionSmoothTime = 0.2f;
    

    private bool _isLit;
    private Vector3 _velocity = Vector3.zero;
    
    // (event) when sparkler runs out
    // (this obj) enable smoke
        // smoke must be visible at night
    // (camera) increase fog, same time as balloons lerp to 9.81
    // (balloons) start balloon fall sequence
        // slowly flatten
        // desaturate as lerp to 9.81
        // acceleration from negative rising then lerp to 9.81
        // turn on collider with detected ground planes
        // if (night) lights dim
        // (event) once particles == 0, disable the balloon spawners

    void Start()
    {
        onSparklerLit ??= new UnityEvent(); // if null, assign.
        onSparklerDeath ??= new UnityEvent(); 
        onSparklerLit.AddListener(LightSparkler);
    }

    void Update()
    {
        if (_isLit)
        {
            // lerp to end
            sparkObj.transform.localPosition = Vector3.SmoothDamp(sparkObj.transform.localPosition, 
                sparkEndPos.localPosition, 
                ref _velocity,
                positionSmoothTime / positionSpeedMultiplier);
        }
    }

    public void LightSparkler()
    {
        sparkObj.SetActive(true);
        sparkObj.transform.localPosition = sparkStartPos.localPosition;
        smokeObj.SetActive(false);
    }

    public void ExtinguishSparkler()
    {
        sparkObj.SetActive(false); 
        smokeObj.SetActive(true);
    }

    public void EnableTrails() { StartCoroutine(DrawTrails()); }
    public void DisableTrails() { friendTrailObj.SetActive(false); }
    private IEnumerator DrawTrails()
    {
        friendTrailObj.SetActive(true);
        yield return new WaitForSeconds(trailTime);
        DisableTrails();
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject other = collision.gameObject;
        SparklerController otherSpkController = other.GetComponent<SparklerController>();
        bool touchedSparkler = otherSpkController != null;
        bool touchedHearth = other.GetComponent<Hearth>() != null;
        
        // exit if the other object is not a hearth or a sparkler
        if (!(touchedSparkler || touchedHearth)) return;

        if (touchedHearth) Debug.Log("touched hearth");
            
        _isLit = true;
        transform.localPosition = sparkStartPos.localPosition;
        onSparklerLit.Invoke();
        
        if (touchedSparkler)
        {
            EnableTrails(); // for this sparkler
            otherSpkController.EnableTrails();
            Debug.Log("touched other sparkler");
        }
    }

    
}