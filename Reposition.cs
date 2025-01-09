using UnityEngine;

public class Reposition : MonoBehaviour
{
    void Update()
    {
        Repos();
    }

    void Repos()
    {
        Vector3 myPos = transform.position;

        if (myPos.x < -12)
            transform.Translate(Vector3.right * 24);
    }
}
