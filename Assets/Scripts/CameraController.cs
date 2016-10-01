using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Camera mainCamera;
    private GameObject player;
    private int viewMode;
    private float cameraOffsetX;
    private float cameraOffsetY;
    private float cameraOffsetZ;


    // Use this for initialization
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        mainCamera.transform.rotation = Quaternion.Euler(new Vector3(15f, 0, 0));

        player = GameObject.Find("Player");
        viewMode = 0;
        updateCamera();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x + cameraOffsetX, playerInfo.y + cameraOffsetY, playerInfo.z + cameraOffsetZ);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            float fYRot = Camera.main.transform.eulerAngles.y;
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(15f, fYRot - 90.0f, 0));
            if (viewMode == 0)
            {
                viewMode = 3;
            }
            else
            {
                viewMode--;
            }
            updateCamera();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            float fYRot = Camera.main.transform.eulerAngles.y;
            mainCamera.transform.rotation = Quaternion.Euler(new Vector3(15f, fYRot + 90.0f, 0));
            if (viewMode == 3)
            {
                viewMode = 0;
            }
            else
            {
                viewMode++;
            }
            updateCamera();
        }

    }

    public int getViewMode()
    {
        return viewMode;
    }

    void updateCamera()
    {
        switch (viewMode)
        {
            case 0:
                cameraOffsetX = 0;
                cameraOffsetY = 2.5f;
                cameraOffsetZ = -7.0f;
                break;
            case 1:
                cameraOffsetX = -7.0f;
                cameraOffsetY = 2.5f;
                cameraOffsetZ = 0;
                break;
            case 2:
                cameraOffsetX = 0;
                cameraOffsetY = 2.5f;
                cameraOffsetZ = 7.0f;
                break;
            case 3:
                cameraOffsetX = 7.0f;
                cameraOffsetY = 2.5f;
                cameraOffsetZ = 0;
                break;
            default:
                Debug.LogError("INVALID CAMERA VIEW MODE!");
                break;
        }
    }

}
