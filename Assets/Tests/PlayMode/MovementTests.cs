using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MovementTests
{
    private GameObject testObject;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        // Create a new GameObject before each test
        testObject = new GameObject("TestObject");
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_Position_Changes()
    {
        // Move the GameObject
        testObject.transform.position = new Vector3(1, 1, 1);

        // Verify that the GameObject's position has changed
        Assert.AreEqual(new Vector3(1, 1, 1), testObject.transform.position);
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
