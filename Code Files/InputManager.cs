using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Vector2 lookInput;

    void Update()
    {
        // Get mouse input
        lookInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
