using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementSpeed = 50f;
    private Vector3 movementRelativeAsTheirKeysPressed = new Vector3();

    private void Update()
    {
        if (CheckIfPressingKey(KeyCode.W, KeyCode.UpArrow))
        {
            movementRelativeAsTheirKeysPressed.z += CalculateMoving();
        }

        if (CheckIfPressingKey(KeyCode.S, KeyCode.DownArrow))
        {
            movementRelativeAsTheirKeysPressed.z -= CalculateMoving();
        }
        
        if (CheckIfPressingKey(KeyCode.A, KeyCode.LeftArrow))
        {
            movementRelativeAsTheirKeysPressed.x -= CalculateMoving();
        }
        
        if (CheckIfPressingKey(KeyCode.D, KeyCode.RightArrow))
        {
            movementRelativeAsTheirKeysPressed.x += CalculateMoving();
        }
        
        this.transform.Translate(movementRelativeAsTheirKeysPressed, Space.World);
        movementRelativeAsTheirKeysPressed = new Vector3();
    }

    private static bool CheckIfPressingKey(params KeyCode[] keyCodesToCheck)
    {
        List<bool> isBeingPressed = new List<bool>();
        
        foreach (var keyCode in keyCodesToCheck)
        {
            isBeingPressed.Add(Input.GetKey(keyCode));
        }

        return isBeingPressed.Any(keysPressed => keysPressed == true);
    }

    private float CalculateMoving()
    {
        return movementSpeed * UnityEngine.Time.deltaTime;
    }

}
