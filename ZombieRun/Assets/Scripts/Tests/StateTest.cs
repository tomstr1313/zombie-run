using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class jumpTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void jumpTestSimplePasses()
        {
            var player = new GameObject();

            player.AddComponent<Rigidbody2D>();
            var originalPos = player.transform.position.x;

            Assert.AreNotEqual(originalPos, 1.2f);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator jumpTestWithEnumeratorPasses()
        {
            var player = new GameObject();

            player.AddComponent<Rigidbody2D>();
            var originalPos = player.transform.position.x;

            yield return null;

            Assert.AreNotEqual(originalPos, 1.2f);

            yield return null;
        }
    }
}