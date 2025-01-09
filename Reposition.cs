using UnityEngine;

public class Reposition : MonoBehaviour
{  
    void Update()
    {
        Repos();
    }

    void Repos()
    {
        if (transform.position.x < -12)
            transform.Translate(Vector3.right * 24);

        for (int i = 0; i < GameManager.instance.cactus.Length; i++)
            GameManager.instance.cactus[i].SpawnCactus();
    }
}
