using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;

    public float movementSpeed = 5.0f;
    public float edgeMovementSpeed = 5.0f;
    public float verticalMovementSpeed = 5.0f;
    public float edgeBorderSize = 5.0f;
    public float rotationSpeed = 100.0f;
    public float rotationMouse = 300.0f;
    public float zoomSpeed = 10.0f;
    public float minZoomDistance = 1.0f;
    public float maxZoomDistance = 30.0f;

    private bool isRotating = false;

    public float distance = 10.0f;
    public float minDistance = 5.0f;
    public float maxDistance = 35.0f;
    public float minTheta = 10.0f;
    public float maxTheta = 80.0f;
    public float theta = 70.0f;
    public float phi;

    public bool allowEdgeMovement;


     void Start()
    {   // PlayerController
        Vector3 toCamera = mainCamera.transform.position - transform.position;
        distance = toCamera.magnitude;
        // Set the initial angle above the horizon
        theta = 45.0f;
        phi = -Vector3.SignedAngle(-Vector3.forward, new Vector3(toCamera.x, 0, toCamera.z), Vector3.up);

        // Set the initial position of the camera based on the new theta value
        Vector3 newPosition = new Vector3(
            transform.position.x + distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Sin(Mathf.Deg2Rad * phi),
            transform.position.y + distance * Mathf.Cos(Mathf.Deg2Rad * theta),
            transform.position.z + distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Cos(Mathf.Deg2Rad * phi)
        );

        mainCamera.transform.position = newPosition;
        mainCamera.transform.LookAt(Vector3.forward);
    }
   
    public void UpdateCameraController()
    {   // PlayerController
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0)
        {
            distance -= scrollWheel * zoomSpeed * 400 * Time.deltaTime;
            distance = Mathf.Clamp(distance, minDistance, maxDistance);
        }

        if (Input.GetMouseButton(2)) // Right mouse button is pressed
        {
            isRotating = true; // Set isPivoting to true
            float mouseX = Input.GetAxis("Mouse X") * rotationMouse * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationMouse * Time.deltaTime;

            // Update angles
            theta = Mathf.Clamp(theta + mouseY, minTheta, maxTheta);
            phi += mouseX;

            // Calculate the new position
            Vector3 newPositionToRotate = new Vector3(
                distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Sin(Mathf.Deg2Rad * phi),
                distance * Mathf.Cos(Mathf.Deg2Rad * theta),
                distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Cos(Mathf.Deg2Rad * phi)
            );

            mainCamera.transform.position = transform.position + newPositionToRotate;
            mainCamera.transform.LookAt(transform.position);
        }
        else
        {
            isRotating = false; // Set isPivoting to false
        }

        // Calculate the new position based on updated distance
        Vector3 newPosition = new Vector3(
            distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Sin(Mathf.Deg2Rad * phi),
            distance * Mathf.Cos(Mathf.Deg2Rad * theta),
            distance * Mathf.Sin(Mathf.Deg2Rad * theta) * Mathf.Cos(Mathf.Deg2Rad * phi)
        );

        mainCamera.transform.position = transform.position + newPosition;
        mainCamera.transform.LookAt(transform.position);

        if (!isRotating)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                mainCamera.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0, Space.World);
            }

            if (Input.GetKey(KeyCode.E))
            {
                mainCamera.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
            }

            // WASD Movement
            float horizontal = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

            Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
            moveDirection = mainCamera.transform.TransformDirection(moveDirection);
            moveDirection.y = 0; // Remove the vertical component

            transform.Translate(moveDirection, Space.World); // Apply movement to the pivot

            // Edge Movement
            if (allowEdgeMovement)
            {
                Vector3 edgeMovement = Vector3.zero;

                if (Input.mousePosition.x <= edgeBorderSize)
                    edgeMovement += new Vector3(-edgeMovementSpeed * Time.deltaTime, 0, 0);

                if (Input.mousePosition.x >= Screen.width - edgeBorderSize)
                    edgeMovement += new Vector3(edgeMovementSpeed * Time.deltaTime, 0, 0);

                if (Input.mousePosition.y <= edgeBorderSize)
                    edgeMovement += new Vector3(0, 0, -edgeMovementSpeed * Time.deltaTime);

                if (Input.mousePosition.y >= Screen.height - edgeBorderSize)
                    edgeMovement += new Vector3(0, 0, edgeMovementSpeed * Time.deltaTime);

                edgeMovement = GetComponent<Camera>().transform.TransformDirection(edgeMovement);
                edgeMovement.y = 0; // Remove the vertical component

                transform.Translate(edgeMovement, Space.World); // Apply movement to the pivot
            }

            // Vertical Movement
            float verticalMovement = 0.0f;

            if (Input.GetKey(KeyCode.P))
                verticalMovement = verticalMovementSpeed * Time.deltaTime;

            if (Input.GetKey(KeyCode.O))
                verticalMovement = -verticalMovementSpeed * Time.deltaTime;

            transform.Translate(0, verticalMovement, 0, Space.World); // Apply movement to the pivot
        }
    }
}
