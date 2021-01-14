﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Gtest1
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Gtest1SimplePasses()
        {
            // Use the Assert class to test conditions
            var x = new TextControl();

            Assert.IsFalse(x.Selectflag);
            //x.chatComent.text = "Matsuno";
            //x.Selecter();
            //Assert.AreEqual(x.chatComent.color, Color.green) ; 
        }

        [Test]
        public void Gtest2SimplePasses()
        {
            // Use the Assert class to test conditions
            var x = new TextControl();
            Assert.IsTrue(x.Selectflag);
        }
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator Gtest1WithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
