using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CommandTest
    {
        private Animator animator;

        // A Test behaves as an ordinary method
        [Test]
        public void CommandTestSimplePasses()
        {
            var running = true;
            var jumping = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                running = false;
                jumping = true;
            }

            Assert.AreNotEqual(running, jumping);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CommandTestWithEnumeratorPasses()
        {
            var running = true;
            var jumping = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                running = false;
                jumping = true;
            }

            Assert.AreNotEqual(running, jumping);

            yield return null;
        }
    }
}