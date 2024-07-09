using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MoveObjectPlayModeTests
{
    private GameObject movableObject;
    private MoveObject moveObjectScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and attach the MoveObject script
        movableObject = new GameObject();
        moveObjectScript = movableObject.AddComponent<MoveObject>();

        // Set direction and speed
        moveObjectScript.direction = Vector2.right;
        moveObjectScript.speed = 1.0f;

        yield return null;
    }

    [UnityTest]
    public IEnumerator MovableObject_MovesInAnyDirection()
    {
        // Record initial position
        Vector3 initialPosition = movableObject.transform.position;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Check if the position has changed
        Assert.AreNotEqual(initialPosition, movableObject.transform.position);
        Assert.AreNotEqual(Vector3.right, moveObjectScript.direction);
    }
    [UnityTest]
    public IEnumerator TestObject_MovesInRightDirection()
    {
        // Record initial position
        Vector3 initialPosition = movableObject.transform.position;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Record new position
        Vector3 newPosition = movableObject.transform.position;

        // Verify that the GameObject has moved in the right direction
        Assert.Greater(newPosition.x, initialPosition.x);
        Assert.AreEqual(initialPosition.y, newPosition.y);
        Assert.AreEqual(initialPosition.z, newPosition.z);
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after the test
        Object.Destroy(movableObject);
        yield return null;
    }
}
