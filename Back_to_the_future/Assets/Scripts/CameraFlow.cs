using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{

    public Transform player;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position;
        position.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, position, velocity * Time.deltaTime);
    }
}
