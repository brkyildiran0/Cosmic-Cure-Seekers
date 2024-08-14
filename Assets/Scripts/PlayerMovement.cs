using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (!IsOwner) return;

        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        transform.Translate(new Vector3(moveX, 0f, moveZ));
    }
}
