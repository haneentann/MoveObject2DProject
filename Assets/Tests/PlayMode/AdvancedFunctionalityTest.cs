using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class AdvancedFunctionalityTest
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
    public IEnumerator TestObject_SpeedBoost()
    {
        // Record initial speed
        float initialSpeed = moveObjectScript.speed;

        // Simulate speed boost
        moveObjectScript.SimulateSpeedBoost();

        // Verify the speed has doubled
        yield return null; // Wait for one frame to ensure the coroutine starts
        Assert.AreEqual(initialSpeed * 2, moveObjectScript.speed);

        // Wait for 2 seconds
        yield return new WaitForSeconds(2.0f);

        // Verify the speed has returned to normal
        Assert.AreEqual(initialSpeed, moveObjectScript.speed);
    }

    [UnityTest]
    public IEnumerator TestObject_Rotate()
    {
        // Record initial rotation
        Quaternion initialRotation = testObject.transform.rotation;

        // Simulate rotation
        moveObjectScript.RotateObject();

        // Verify the object has rotated 90 degrees
        yield return null; // Wait for one frame to ensure the rotation is applied
        Quaternion expectedRotation = initialRotation * Quaternion.Euler(0, 0, 90);
        Assert.AreEqual(expectedRotation.eulerAngles.z, moveObjectScript.transform.rotation.eulerAngles.z);
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after each test
        Object.Destroy(testObject);    
        yield return null;
    }
}
