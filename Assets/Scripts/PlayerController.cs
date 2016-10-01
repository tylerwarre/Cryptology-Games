using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    private float speed = 10.0F;
    private float rotationSpeed = 20.0F;
    public int viewMode;
    private int directionX;
    private int directionY;
    private bool useHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        viewMode = 0;
        updateControl();
    }

    void FixedUpdate()
    {

        float moveHorizontal = directionX * Input.GetAxis("Horizontal") * rotationSpeed;
        float moveVertical = directionY * Input.GetAxis("Vertical") * speed;
        Vector3 movement;

        if (useHorizontal)
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }
        else
        {
            movement = new Vector3(moveVertical, 0.0f, moveHorizontal);
        }

        rb.AddForce(movement);

        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (viewMode == 0)
            {
                viewMode = 3;
            }
            else
            {
                viewMode--;
            }
            updateControl();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (viewMode == 3)
            {
                viewMode = 0;
            }
            else
            {
                viewMode++;
            }
            updateControl();
        }

    }

    void updateControl()
    {
        switch (viewMode)
        {
            case 0:
                useHorizontal = true;
                directionX = 1;
                directionY = 1;
                break;
            case 1:
                useHorizontal = false;
                directionX = -1;
                directionY = 1;
                break;
            case 2:
                useHorizontal = true;
                directionX = -1;
                directionY = -1;
                break;
            case 3:
                useHorizontal = false;
                directionX = 1;
                directionY = -1;
                break;
            default:
                Debug.LogError("INVALID CAMERA VIEW MODE!");
                break;
        }
    }
}
