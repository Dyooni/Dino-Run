using UnityEngine;

public class Reposition : MonoBehaviour
{
    Vector3 myPos;
    void Update()
    {
        Repos();
    }

    void Repos()
    {
        myPos = transform.position;

        if (myPos.x < -12)
            transform.Translate(Vector3.right * 24);
    }
}
