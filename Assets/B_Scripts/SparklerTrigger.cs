using UnityEngine;

/// <summary>
/// Simple class that lights the sparkler if touched another sparkler or the hearth
/// </summary>
public class SparklerTrigger : MonoBehaviour
{
    [SerializeField] private SparklerController ctrlr;
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        bool hasTouchedSparkler = go.GetComponent<SparklerTrigger>() != null;
        bool hasTouchedHearth = go.GetComponent<Hearth>() != null;
        
        // exit if the other object is not a hearth or a sparkler
        if (!(hasTouchedHearth || hasTouchedSparkler)) return;
            
        ctrlr.LightSparkler();
        
        // enable trails for both sparklers
        if (hasTouchedSparkler)
        {
            ctrlr.EnableTrails();
            go.GetComponent<SparklerTrigger>().EnableParentTrails();
        }
    }

    public void EnableParentTrails()
    {
        ctrlr.EnableTrails();
    }
}
