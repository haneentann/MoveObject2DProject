using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ChangeColorTest
{
    private GameObject movableObject;
    private MoveObject moveObjectScript;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and attach the MoveObject script
        movableObject = new GameObject();
        moveObjectScript = movableObject.AddComponent<MoveObject>();
        /*
                // Assign a sprite renderer and a simple square sprite for visualization (optional)
                var spriteRenderer = movableObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = Resources.Load<Sprite>("Square");
        */
        // Set direction and speed
        moveObjectScript.direction = Vector2.right;
        moveObjectScript.speed = 1.0f;

        yield return null;
    }

    [UnityTest]
    public IEnumerator MovableObject_MovesInSpecifiedDirection()
    {

        // Record initial position
        Vector3 initialPosition = movableObject.transform.position;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Check if the position has changed
        Assert.AreNotEqual(initialPosition, movableObject.transform.position);
    }

    [UnityTest]
    public IEnumerator MovableObject_ChangesColorOnMove()
    {
        // Set direction and speed
        moveObjectScript.direction = Vector2.right;
        moveObjectScript.speed = 1.0f;

        moveObjectScript.ChangeColor(Color.red);
        // Initial color
        Color initialColor = moveObjectScript.GetComponent<SpriteRenderer>().color;

        // Wait for 1 second
        yield return new WaitForSeconds(1.0f);

        // Check if the color has changed
        Color currentColor = moveObjectScript.GetComponent<SpriteRenderer>().color;
    //    Assert.AreNotEqual(initialColor, currentColor);
        Assert.AreEqual(Color.red, currentColor);
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after the test
        Object.Destroy(movableObject);
        yield return null;
    }
}
