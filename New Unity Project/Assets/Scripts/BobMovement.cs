using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BobMovement : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    PhotonView view;
    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;

    void Start()
    {
        view = GetComponent<PhotonView>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * runSpeed * Time.deltaTime;
        if (!spriteRenderer.isVisible)
        {
            transform.position = new Vector2(0, 0);
        }

        }
    }

    private void FixedUpdate()
    {
    }
}
