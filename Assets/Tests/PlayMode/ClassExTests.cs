using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ClassExTests
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
    public IEnumerator TestObject_ResetPosition()
    {
        // Move the object for 1 second
        yield return new WaitForSeconds(1.0f);

        // Verify the object has moved
        Assert.AreNotEqual(Vector3.zero, testObject.transform.position);

        // Reset position
        moveObjectScript.ResetPosition();

        // Verify the object is back to the initial position
        Assert.AreEqual(Vector3.zero, testObject.transform.position);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_ToggleVisibility()
    {
        // Verify initial visibility
        Assert.IsTrue(testObject.GetComponent<SpriteRenderer>().enabled);

        // Toggle visibility
        moveObjectScript.ToggleVisibility();

        // Verify visibility is toggled off
        Assert.IsFalse(testObject.GetComponent<SpriteRenderer>().enabled);

        // Toggle visibility again
        moveObjectScript.ToggleVisibility();

        // Verify visibility is toggled on
        Assert.IsTrue(testObject.GetComponent<SpriteRenderer>().enabled);

        yield return null;
    }
    [UnityTest]
    public IEnumerator TestObject_ChangeSpeed()
    {
        // Move the object for 1 second with initial speed
        yield return new WaitForSeconds(1.0f);

        // Record the position
        Vector3 initialPosition = testObject.transform.position;

        // Change the speed
        moveObjectScript.ChangeSpeed(2.0f);

        // Assert the speed has changed
        Assert.AreEqual(2.0f, moveObjectScript.speed);

        // Move the object for 1 more second with new speed
        yield return new WaitForSeconds(1.0f);

        // Verify the object has moved faster
        Assert.Greater(testObject.transform.position.x, initialPosition.x + 1.0f);

        yield return null;
    }

    [UnityTest]
    public IEnumerator ClassExTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
