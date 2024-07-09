using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class SimpleGameObjectTests
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
    public IEnumerator TestObject_IsCreated()
    {
        // Verify that the GameObject is created
        Assert.IsNotNull(testObject);
        Assert.AreEqual("TestObject", testObject.name);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestObject_Position_IsZero()
    {
        // Verify that the GameObject's position is (0, 0, 0)
        Assert.AreEqual(Vector3.zero, testObject.transform.position);
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
