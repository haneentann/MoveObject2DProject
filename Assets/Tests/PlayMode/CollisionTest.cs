using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MoveObjectCollisionTest
{
    private GameObject staticSquare;
    private GameObject movingSquare;
    private MoveObject moveObjectScript;
    private Rigidbody2D movingRb;

    [SetUp]
    public void SetUp()
    {
        // Create Static Square
        staticSquare = new GameObject("StaticSquare");
        staticSquare.AddComponent<BoxCollider2D>(); // Add BoxCollider2D for collision detection
        var staticRb = staticSquare.AddComponent<Rigidbody2D>();
        staticRb.isKinematic = true; // Ensure it's static by setting isKinematic to true
        //var staticRenderer = staticSquare.AddComponent<SpriteRenderer>(); //in case you want to change the static object      
        staticSquare.tag = "Enemy"; // Set tag to Enemy for collision identification as programmed in MoveObjects

        // Create Moving Square
        movingSquare = new GameObject("MySprite");
        movingSquare.AddComponent<BoxCollider2D>(); // Add BoxCollider2D for collision detection
        movingRb = movingSquare.AddComponent<Rigidbody2D>();
        movingRb.isKinematic = true; //will be changed inside testa
       
        // Add MoveObject script to Moving Square
        moveObjectScript = movingSquare.AddComponent<MoveObject>();
        moveObjectScript.direction = Vector2.right; // Move right towards StaticSquare
        moveObjectScript.speed = 2.0f;

        // Position the squares
        staticSquare.transform.position = Vector3.zero;
        movingSquare.transform.position = new Vector3(-2, 0, 0);
    }

    [UnityTest]
    public IEnumerator TestCollisionStopsMovingSquareAndChangesColor()
    {
        // Enable Rigidbody movement
        movingRb.isKinematic = false;

        // Wait for the moving square to collide with the static square
        yield return new WaitForSeconds(1.5f);

        // Check if the color has changed to blue
        Assert.AreEqual(Color.blue, movingSquare.GetComponent<SpriteRenderer>().color);

        // Check if the speed is set to zero
        Assert.AreEqual(0, moveObjectScript.speed);
    }


    [TearDown]
    public void TearDown()
    {
        // Clean up
        Object.Destroy(staticSquare);
        Object.Destroy(movingSquare);
    }
}
