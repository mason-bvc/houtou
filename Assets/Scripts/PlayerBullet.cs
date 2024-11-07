using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector3 Direction;

    [SerializeField]
    public float Speed = 400.0F;

    [SerializeField]
    public float DestroyDistanceSquared = 160000.0F;

    public void FixedUpdate()
    {
        transform.Translate(Direction * Speed * Time.fixedDeltaTime);

        if (transform.position.sqrMagnitude > DestroyDistanceSquared)
        {
            Destroy(gameObject);
        }
    }
}
