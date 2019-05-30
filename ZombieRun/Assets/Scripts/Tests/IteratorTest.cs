using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class IteratorTest
    {
        public GameObject item;
        public GameObject clone;
        public GameObject instance;

        private List<GameObject> pool = new List<GameObject>();

        // A Test behaves as an ordinary method
        [Test]
        public void IteratorTestSimplePasses()
        {

            GameObject createInstance(Vector3 pos)
            {
                clone = GameObject.Instantiate(item);
                clone.transform.position = pos;
                pool.Add(clone);
                return clone;
            }

            GameObject NextObject(Vector3 pos)
            {
                instance = null;

                foreach(var go in pool)
                {
                    if(go.gameObject.activeSelf != true)
                    {
                        instance = go;
                        instance.transform.position = pos;
                    }
                }
                if(instance == null)
                instance = createInstance(pos);
                return instance;
            }

            Assert.AreEqual(instance,item);
        }
           

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator IteratorTestWithEnumeratorPasses()
        {
            GameObject createInstance(Vector3 pos)
            {
                clone = GameObject.Instantiate(item);
                clone.transform.position = pos;
                pool.Add(clone);
                return clone;
            }

            GameObject NextObject(Vector3 pos)
            {
                instance = null;

                foreach (var go in pool)
                {
                    if (go.gameObject.activeSelf != true)
                    {
                        instance = go;
                        instance.transform.position = pos;
                    }
                }
                if (instance == null)
                    instance = createInstance(pos);
                return instance;
            }

            Assert.AreEqual(instance, item);

            yield return null;
        }
    }
}