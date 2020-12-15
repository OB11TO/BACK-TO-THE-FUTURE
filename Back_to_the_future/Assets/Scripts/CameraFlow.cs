using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{

    Camera mainCamera;

    public Transform player;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position;
        position.z = transform.position.z;

        if (position.x < 0f) position.x = 0f;

        transform.position = Vector3.Lerp(transform.position, position, velocity * Time.deltaTime);
    }

}
