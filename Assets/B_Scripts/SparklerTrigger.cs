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
        if (go.GetComponent<Hearth>() != null)
        {
            ctrlr.LightSparkler();
            return;
        }
        
        SparklerTrigger spkTrig = go.GetComponent<SparklerTrigger>();
        if (spkTrig == null || !spkTrig.IsLit()) return;
        
        // enable trails for both sparklers
        ctrlr.LightSparkler();
        ctrlr.EnableTrails();
    }

    public bool IsLit()
    {
        return ctrlr.isLit;
    }
}
