using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera secondCamera;
    private KeyCode switchCameraKey = KeyCode.Space;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(switchCameraKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secondCamera.enabled = !secondCamera.enabled;
        }

    }
}
