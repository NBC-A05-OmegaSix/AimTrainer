using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 500f;

    private float rotationX;
    private float rotationY;

    [SerializeField]
    private GameObject cameraPosition;
    private float mouseSensitivityMultiplier = 1f;
    void Start()
    {
    }

    void Update()
    {
        float mouseMoveX = Input.GetAxis("Mouse X");
        float mouseMoveY = Input.GetAxis("Mouse Y");
        rotationY += mouseMoveX * sensitivity * Time.deltaTime;
        rotationX += mouseMoveY * sensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -35f, 35f);

        transform.eulerAngles = new Vector3(0, rotationY, 0);
        cameraPosition.transform.localEulerAngles = new Vector3(-rotationX, 0, 0);
    }
        public void SetMouseSensitivity(float sensitivityValue)
    {
        sensitivity = sensitivityValue;
    }
}
