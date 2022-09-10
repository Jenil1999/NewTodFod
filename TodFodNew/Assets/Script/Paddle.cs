using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenWidthLimit = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15.04f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MousePos = Input.mousePosition.x / Screen.width * ScreenWidthLimit;
        Vector2 paddlepos = new Vector2(transform.position.x, transform.position.y);
        paddlepos.x = Mathf.Clamp(MousePos, minX, maxX);
        transform.position = paddlepos;
    }
}
