using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class templateTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void templateTestSimplePasses()
        {
            int enemyHealth = 100;
            int bulletDamage = 100;

            int damage = enemyHealth - bulletDamage;

            Assert.AreNotEqual(enemyHealth, damage);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator templateTestWithEnumeratorPasses()
        {
            int enemyHealth = 100;
            int bulletDamage = 100;
        
            int damage = enemyHealth - bulletDamage;

            yield return null;

            Assert.AreNotEqual(enemyHealth, damage);

            yield return null;
        }
    }
}