using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed;


    void FixedUpdate() {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }
}
