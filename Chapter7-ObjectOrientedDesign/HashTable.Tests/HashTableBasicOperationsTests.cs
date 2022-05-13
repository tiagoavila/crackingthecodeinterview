using NUnit.Framework;
using System;

namespace HashTable.Tests
{
    public class HashTableBasicOperationsTests
    {
        private readonly Core.HashTable<string, int> _hashTable;

        public HashTableBasicOperationsTests()
        {
            _hashTable = new Core.HashTable<string, int>(10);
        }

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddAnItemWorks()
        {
            _hashTable.Add("Tiago", 30);
            _hashTable.Add("John", 50);
            
            Assert.IsNotNull(_hashTable.Get("Tiago"));
        }

        [Test]
        public void UpdateAnItemWorks()
        {
            _hashTable.Add("Tiago", 25);
            _hashTable.Add("Tiago", 30);

            Assert.AreEqual(_hashTable.Get("Tiago"), 30);
        }

        [Test]
        public void GetAKeyThatDoesntExistReturnsANullValue()
        {
            _hashTable.Add("Tiago", 30);

            Assert.AreEqual(_hashTable.Get("Joao"), default(int));

            int result = Math.Abs("Tiago".GetHashCode() % 10);
            int result4 = Math.Abs("Iago".GetHashCode() % 10);
            int result1 = Math.Abs("Test".GetHashCode() % 10);
            int result2 = Math.Abs("Rita".GetHashCode() % 10);
            int result3 = Math.Abs("Joao".GetHashCode() % 10);
            int result5 = Math.Abs("A".GetHashCode() % 10);
            int result6 = Math.Abs("T".GetHashCode() % 10);
            int result7 = Math.Abs("J".GetHashCode() % 10);
            int result8 = Math.Abs("Hollanda".GetHashCode() % 10);
            int result9 = Math.Abs("John".GetHashCode() % 10);
        }
    }
}