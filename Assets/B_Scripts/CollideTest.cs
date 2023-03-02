using UnityEngine;

public class CollideTest : MonoBehaviour
{
    /// <summary>
    /// Activated by collider that isTrigger, with rigidbody that isKinematic,
    /// and not the parent of the moving AR object
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name}: OnTriggered. Collided with: {other.name}");
    }

}
