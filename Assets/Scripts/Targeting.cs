using System.Security.Principal;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public GameObject player;

    // The object to orbit around
    public Transform centerObject;

    // Radius of the circle
    float radius;

    // Speed of orbit
    public float speed = 1f;       

    private float angle = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = Random.Range(4, 7);
        Debug.Log(radius);
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
        // Speed depends on radius
        float orbitSpeed = speed * radius / 2;

        // Calculate the new position
        angle += orbitSpeed * Time.deltaTime;
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
        transform.rotation = Quaternion.Euler(0, 0, angle -90) * Quaternion.Euler(0, angle -90, 0);
    }
}
