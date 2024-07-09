using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MovementControlTests
{
    private GameObject testObject;
    private MoveObject moveObjectScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and attach the MoveObject script
        testObject = new GameObject("TestObject");
        moveObjectScript = testObject.AddComponent<MoveObject>();

        // Assign a sprite renderer and a simple square sprite for visualization
        var spriteRenderer = testObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Square");

        // Set the direction and speed
        moveObjectScript.direction = Vector2.right;
        moveObjectScript.speed = 1.0f;

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_StopsOnMethodCall()
    {
        // Let the object move for 1 second
        yield return new WaitForSeconds(1.0f);

        // Record the position after 1 second
        Vector3 positionBeforeStop = testObject.transform.position;

        // Simulate stop movement method call
        moveObjectScript.StopMovement();

        // Let 1 second pass to verify if it has stopped
        yield return new WaitForSeconds(1.0f);

        // Record the position after stopping
        Vector3 positionAfterStop = testObject.transform.position;

        // Verify that the GameObject's position has not changed after stopping
        Assert.AreEqual(positionBeforeStop, positionAfterStop);
    }

    [UnityTest]
    public IEnumerator TestObject_ChangesDirectionOnMethodCall()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Record position before changing direction
        Vector3 positionBeforeChange = testObject.transform.position;

        // Simulate change direction method call
        moveObjectScript.ChangeDirection();
        yield return new WaitForSeconds(1.0f);

        // Record the position
        Vector3 newPosition = testObject.transform.position;

        // Verify that the GameObject's direction has changed to the opposite
        Assert.Less(newPosition.x, positionBeforeChange.x); // Since initial direction is right, it should move left
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after each test
        Object.Destroy(testObject);
        yield return null;
    }
}
