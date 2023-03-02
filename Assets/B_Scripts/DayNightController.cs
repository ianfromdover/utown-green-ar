using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I don't think we have time to implement this but
/// Gets the time from the phone's clock once at app launch and uses it to
/// trigger day night lights being on or off.
/// </summary>
public class DayNightController : MonoBehaviour
{
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject moon;
    [SerializeField] private List<ParticleSystem> balloons;
    void Start()
    {
        // ------7am sunrise ----- 7pm sunset -----
        // app default state is daytime
        // whats the datatype for time
        if (true /*7am < time < 7pm*/) // daytime
        {
            sun.SetActive(true);
            moon.SetActive(false);
            // disable balloon lights
            foreach (ParticleSystem ps in balloons)
            {
                var l = ps.lights;
                l.enabled = false;
            }
        }
        else
        {
            moon.SetActive(true);
            sun.SetActive(false);
            // enable balloon lights
            foreach (ParticleSystem ps in balloons)
            {
                var l = ps.lights;
                l.enabled = true;
            }
        }
        
    }
    
    // use coroutine until sunset to trigger change lights
}
