using System.Security.Principal;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public GameObject player;

    // The object to orbit around
    public Transform centerObject;

    // Radius of the circle
    public float radius = 2f;

    // Speed of orbit
    public float speed = 1f;       

    private float angle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation around the player
        Rotation();

        //Look at the player
        LookAtPlayer();

    }

    public void Rotation()
    {
        // Calculate the new position
        angle += speed * Time.deltaTime;
        float x = centerObject.position.x + Mathf.Cos(angle) * radius;
        float y = centerObject.position.z + Mathf.Sin(angle) * radius;

        // Update the position
        transform.position = new Vector3(x, y, transform.position.z);

    }

    public void LookAtPlayer()
    {
        // Rotate to face the player
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);

        // Adjust the rotation to make the object face the player correctly
        transform.rotation = Quaternion.Euler(0, 0, angle -90);
    }
}
