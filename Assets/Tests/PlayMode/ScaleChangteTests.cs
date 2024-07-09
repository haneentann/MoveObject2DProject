using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ScaleChangteTests
{
    private GameObject testObject;
    private MoveObject moveObjectScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and attach the MoveObject script
        testObject = new GameObject("TestObject");
        moveObjectScript = testObject.AddComponent<MoveObject>();
        
/*        // Assign a sprite renderer and a simple square sprite for visualization
        var spriteRenderer = testObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Square");*/

        // Set the direction and speed
        moveObjectScript.direction = Vector2.right;
        moveObjectScript.speed = 1.0f;

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_MovesInRightDirection()
    {
        // Record initial position
        Vector3 initialPosition = testObject.transform.position;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Record new position
        Vector3 newPosition = testObject.transform.position;

        // Verify that the GameObject has moved in the right direction
        Assert.Greater(newPosition.x, initialPosition.x);
        Assert.AreEqual(initialPosition.y, newPosition.y);
        Assert.AreEqual(initialPosition.z, newPosition.z);
    }

    [UnityTest]
    public IEnumerator TestObject_ScaleChangesWithMovement()
    {
        // Record initial scale
        Vector3 initialScale = testObject.transform.localScale;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Record new scale
        Vector3 newScale = testObject.transform.localScale;

        // Verify that the GameObject's scale has changed
     //   Assert.AreNotEqual(initialScale, newScale);
        Assert.AreEqual(new Vector3(2, 1, 1), newScale); // Based on direction.x = 1, direction.y = 0
    }

    [UnityTest]
    public IEnumerator TestObject_SpriteRenderer_IsAssigned()
    {
        // Assign a sprite renderer and a simple square sprite for visualization (optional)
        var spriteRenderer = testObject.GetComponent<SpriteRenderer>();
       
        // Verify that the SpriteRenderer component is assigned
        Assert.IsNotNull(spriteRenderer);
        yield return null;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after each test
        Object.Destroy(testObject);
        Object.Destroy(moveObjectScript);
        yield return null;
    }
}
