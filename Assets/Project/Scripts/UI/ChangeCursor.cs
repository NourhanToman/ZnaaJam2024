using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    [SerializeField] Texture2D cursorArrowIdle;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorArrowIdle, Vector2.zero, CursorMode.ForceSoftware);
    }

}
