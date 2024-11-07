using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    public float Speed = 400.0F;

    [SerializeField]
    public float DestroyDistanceSquared = 160000.0F;

    public void FixedUpdate()
    {
        transform.Translate(transform.up * Speed * Time.fixedDeltaTime, Space.World);

        if (transform.position.sqrMagnitude > DestroyDistanceSquared)
        {
            Destroy(gameObject);
        }
    }
}
