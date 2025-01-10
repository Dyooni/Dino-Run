using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;


    void FixedUpdate()
    {
        if (GameManager.instance.player.isLive)
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
