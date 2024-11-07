using UnityEngine;

public class Background : MonoBehaviour
{
    public void Update()
    {
        transform.localScale = new(Camera.main.orthographicSize * Camera.main.aspect, 1, Camera.main.orthographicSize);
    }
}
