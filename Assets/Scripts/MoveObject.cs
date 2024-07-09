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
        //phase2
     //   ChangeColor(Color.red);

        //Phases3
        // Change scale based on movement
        if (spriteRenderer != null)
        {
            float newScaleX = Mathf.Abs(direction.x) > 0 ? Mathf.Abs(direction.x) * 2 : 1;
            float newScaleY = Mathf.Abs(direction.y) > 0 ? Mathf.Abs(direction.y) * 2 : 1;
            transform.localScale = new Vector3(newScaleX, newScaleY, 1);
        }

        //phase4
        HandleInput();

    }
    //Phase2
    public void ChangeColor(Color newColor)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = newColor;
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
    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
