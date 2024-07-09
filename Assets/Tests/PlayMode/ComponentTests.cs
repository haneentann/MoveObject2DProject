using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ComponentTests
{
    private GameObject testObject;
    private Rigidbody2D rb2D;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject and add a Rigidbody2D component before each test
        testObject = new GameObject("TestObjectWithComponent");
        rb2D = testObject.AddComponent<Rigidbody2D>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator Component_IsAdded()
    {
        // Verify that the Rigidbody2D component is added to the GameObject
        Assert.IsNotNull(rb2D);
        Assert.IsTrue(testObject.TryGetComponent<Rigidbody2D>(out rb2D));
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
