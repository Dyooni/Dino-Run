using UnityEngine;

public class Reposition : MonoBehaviour
{  
    void Update()
    {
        CheckAndRePosition();
    }

    void CheckAndRePosition()
    {
        if (transform.position.x < -12)
            transform.Translate(Vector3.right * 24);

        //foreach (var cactus in GameManager.instance.cactus)
        //    cactus.UpdateCactusState();

        //for (int i = 0; i < GameManager.instance.cactus.Length; i++)
        //    GameManager.instance.cactus[i].UpdateCactusState();
    }
}
