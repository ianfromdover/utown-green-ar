using UnityEngine;
using Niantic.ARDK.Extensions;

public class SendARTransform : MonoBehaviour
{
    public ARNetworkingManager arManager;
    public Transform GetTransform()
    {
        return gameObject.transform;
    }
}
