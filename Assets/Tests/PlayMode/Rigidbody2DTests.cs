using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Rigidbody2DTests
{
    private GameObject testObject;
    private Rigidbody2D rb2D;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and add a Rigidbody2D component
        testObject = new GameObject("TestObjectWithRigidbody");
        rb2D = testObject.AddComponent<Rigidbody2D>();

        // Ensure the Rigidbody2D is set up correctly
        rb2D.gravityScale = 0; // Disable gravity for the test

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_MovesWhenForceApplied()
    {
        // Apply a force to the Rigidbody2D
        Vector2 force = new Vector2(10, 0);
        rb2D.AddForce(force, ForceMode2D.Impulse);

        // Wait for a short period to let physics simulation take place
        yield return new WaitForSeconds(0.1f);

        // Verify that the GameObject has moved
        Assert.AreNotEqual(Vector2.zero, rb2D.velocity);
        Assert.Greater(rb2D.velocity.x, 0);

        yield return null;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        // Destroy the GameObject after each test
        Object.Destroy(testObject);
        yield return null;
    }
}
