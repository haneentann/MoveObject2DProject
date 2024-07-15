using System.Collections;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    //Phase1
    public Vector2 direction;
    public float speed = 1.0f;
    //phase2
    private SpriteRenderer spriteRenderer;

    //phase4
    private bool isMoving = true;

    //phase5
    private Vector3 initialPosition;
    
    //phase 6
    private float normalSpeed;


    //Phase2 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        //phase 5
        initialPosition = transform.position;
        //phase 6
        normalSpeed = speed;
        Debug.Log("Start Log!");
        //phase2
        ChangeColor(Color.red);


    }

    //Phase1
    void Update()
    {
        //phase4
        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        //phase1 uncomment 
        //transform.Translate(direction * speed * Time.deltaTime);
      
        //Phases3
        // Change scale based on movement
       /* if (spriteRenderer != null)
        {
            float newScaleX = Mathf.Abs(direction.x) > 0 ? Mathf.Abs(direction.x) * 2 : 1;
            float newScaleY = Mathf.Abs(direction.y) > 0 ? Mathf.Abs(direction.y) * 2 : 1;
            transform.localScale = new Vector3(newScaleX, newScaleY, 1);
        }*/

        //phase4
        HandleInput();
    //    Debug.Log("Update Log!");

    }
    //Phase2
    public void ChangeColor(Color newColor)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = newColor;
            //Debug.Log("Color Changed Log!");
        }
    }

    //phase4
    // Methods to simulate input for testing
    public void StopMovement()
    {
        isMoving = false;
    }

    public void ChangeDirection()
    {
        direction = -direction;
    }
    public void HandleInput()
    {
        // Check for input to stop or change direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = !isMoving;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            direction = -direction;
        }
        //phase 6
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(SpeedBoost());
        }
        //phase 7
        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateObject();
        }
    }
    //phase 5
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
    public void ToggleVisibility()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
        }
    }

    //phase 6
    //Coroutine
    public IEnumerator SpeedBoost()
    {
        speed *= 2;
        yield return new WaitForSeconds(2.0f);
        speed = normalSpeed;
    }
    public void SimulateSpeedBoost()
    {
        StartCoroutine(SpeedBoost());
    }

    //phase 7 Rotate Object on R Click
    public void RotateObject()
    {
        transform.Rotate(0, 0, 90);
    }
    //phase8 - Collision detection and state change
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D is Entered");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeColor(Color.blue);
            ChangeSpeed(0);
        }
    }   
    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

}
