using UnityEngine;

public class CollideTest : MonoBehaviour
{
    /// <summary>
    /// Called when this collider / rigidbody touches another rigidbody / collider
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name}: OnCollision GOOD. Collided with: {collision.gameObject.name}");
    }

    /// <summary>
    /// Happens on fixedupdate, collision may not be on the point of initial contact
    /// to activate this function,
    ///     both need collider
    ///     1 or more isTrigger
    ///     (can still be called if both dont have rigidbody)
    /// 
    /// to get physical collision,
    ///     both need collider component.
    ///     is trigger disabled
    ///     both have rigidbody
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{gameObject.name}: OnTrigger GOOD. Collided with: {other.name}");
    }

}
