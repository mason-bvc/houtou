using UnityEngine;

public class RotationLock : MonoBehaviour
{
    public void Update()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.rotation);
    }
}
