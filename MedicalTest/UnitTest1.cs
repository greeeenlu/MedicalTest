using System;
using System.Collections.Generic;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MedicalTest
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(106, "2", true)]
        [TestCase(106, "11", true)]
        [TestCase(106, "0", false)]
        [TestCase(106, "12", false)]
        [TestCase(106, "99", true)]
        [TestCase(107, "2a", true)]
        [TestCase(107, "2b", true)]
        [TestCase(107, "14", true)]
        [TestCase(107, "1", true)]
        [TestCase(107, "2", false)]
        [TestCase(107, "12", false)]
        [TestCase(107, "99", true)]
        [TestCase(107, "abc", false)]
        public void valid_list(int year, string content, bool expected)
        {
            var medical = new Medical(year, content);
            Assert.AreEqual(expected, medical.IsValid());
        }
    }

    public class Medical
    {
        private readonly int _year;
        private readonly string _content;

        public Medical(int year, string content)
        {
            _year = year;
            _content = content;
        }

        public bool IsValid()
        {
            switch (_year)
            {
                case 106:
                    return (int.TryParse(_content, out int _intContent) 
                            //&& _content(a => a >= 1 && a < = 11)
                            && rangeValid(_intContent, 1, 11) 
                            || _intContent == 99);
                case 107:

                    return (_content == "2a" || _content == "2b")
                        || (int.TryParse(_content, out int _intContent2) 
                            && Exclude(_intContent2, new List<int>(){2, 12}) 
                            && rangeValid(_intContent2, 1, 14) 
                            || _intContent2 == 99);
            }

            return false;
        }

        private static bool Exclude(int _intContent2, List<int> excludeList)
        {
            return excludeList.Contains(_intContent2) == false;
        }

        private static bool rangeValid(int _intContent, int start, int end)
        {
            return (_intContent >= start && _intContent <= end);
        }
    }
}
