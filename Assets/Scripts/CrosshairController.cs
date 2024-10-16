using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    private RectTransform crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        crosshair = GetComponent<RectTransform>();
        crosshair.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }
        crosshair.position = Input.mousePosition;
        crosshair.SetAsLastSibling();
    }
}
