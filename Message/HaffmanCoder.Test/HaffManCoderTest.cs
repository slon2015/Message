using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Packager;

namespace HaffmanCoder.Test
{
    [TestClass]
    public class HaffManCoderTest
    {
        //[TestMethod]
        //public void HaffmanCoderCode_yyzzzxxx_xCode()
        //{
        //    Packager.HaffmanCoder.HTree tree = new Packager.HaffmanCoder.HTree();
        //    tree.Code("yyzzzxxx");

        //    string expected = "101";

        //    string result = tree.getCodeOf('x');
        //    Assert.AreEqual(expected, result);
        //}
        [TestMethod]
        public void Code_valueEqualsDecompressedValue()
        {
            
            var info = Packager.HaffmanCoder.Code("yyzzzxxx");

            string decompressedValue = "";
            for (int i = 0; i < info.CompressedValue.Length; i++)
            {
                string bits = Convert.ToString((int)info.CompressedValue[i], 2);
                while (bits.Length < 16 && i != info.CompressedValue.Length - 1)
                    bits = "0" + bits;
                decompressedValue += bits;
            }

            Assert.AreEqual(info.value, decompressedValue);
        }
    }
}
