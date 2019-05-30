using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class objectPoolTest
    {
        public GameObject player;
        public GameObject clone;

        private List<GameObject> pool = new List<GameObject>();

        // A Test behaves as an ordinary method
        [Test]
        public void objectPoolTestSimplePasses()
        {
            GameObject createInstance(Vector3 pos)
            {
                clone = GameObject.Instantiate(player);
                clone.transform.position = pos;
                pool.Add(clone);
                return clone;

            }

            Assert.AreSame(player, clone);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator objectPoolTestWithEnumeratorPasses()
        {           
            GameObject createInstance(Vector3 pos)
            {
                clone = GameObject.Instantiate(player);
                clone.transform.position = pos;               
                pool.Add(clone);
                return clone;

            }

            Assert.AreSame(player, clone);

            yield return null;
        }
    }
}

