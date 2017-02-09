﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RabbitMQWebApi.Library.Models.Binding;
using RabbitMQWebAPI.Library.Models.Binding;

namespace RabbitMQWebAPI.Tests
{
    [TestClass]
    public class BindingInfoSentinelTest
    {

        private List<Dictionary<string, object>> testValues = new List<Dictionary<string, object>>();

        private void populateTestValues()
        {
            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
            dictionary1.Add("source", "abc");
            dictionary1.Add("vhost", "abc");
            dictionary1.Add("destination", "abc");
            dictionary1.Add("destination_type", "abc");
            dictionary1.Add("routing_key", "abc");
            dictionary1.Add("arguments", "{}");
            dictionary1.Add("properties_key", "abc");

            Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
            dictionary2.Add("source", "def");
            dictionary2.Add("vhost", "def");
            dictionary2.Add("destination", "def");
            dictionary2.Add("destination_type", "def");
            dictionary2.Add("routing_key", "def");
            dictionary2.Add("arguments", "{}");
            dictionary2.Add("properties_key", "def");        

            testValues.Add(dictionary1);
            testValues.Add(dictionary2);
          
        }

        [TestMethod]
        public void validateDictionary_Test()
        {
            populateTestValues();

            List<bool> expectedList = new List<bool>();
            List<bool> actualList = new List<bool>();

            expectedList.Add(true);
            expectedList.Add(true);
            expectedList.Add(true);
            expectedList.Add(true);

            BindingInfoSentinel sentinel = new BindingInfoSentinel();

            foreach (Dictionary<string, object> dictionary in testValues)
            {
                actualList.Add(sentinel.ValidateDictionary(dictionary));
            }

            for (int i = 0; i <= expectedList.Count; i++)
            {
                Assert.IsTrue(expectedList[i] == actualList[i]);
            }


        }

        [TestMethod]
        public void ParseDictionaryToBindingParameters_Test()
        {
            populateTestValues();
            List<BindingInfoParameters> expectedList = new List<BindingInfoParameters>();
            List<BindingInfoParameters> actualList = new List<BindingInfoParameters>();

            BindingInfoParameters parameters1 = new BindingInfoParameters();
            parameters1.arguments = null;
            parameters1.destination = "abc";
            parameters1.destination_type = "abc";
            parameters1.properties_key = "abc";
            parameters1.routing_key = "abc";
            parameters1.source = "abc";
            parameters1.vhost = "abc";

            BindingInfoParameters parameters2 = new BindingInfoParameters();
            parameters2.arguments = new Dictionary<string,string>();
            parameters2.destination = "def";
            parameters2.destination_type = "def";
            parameters2.properties_key = "def";
            parameters2.routing_key = "def";
            parameters2.source = "def";
            parameters2.vhost = "def";

            
            expectedList.Add(parameters1);
            expectedList.Add(parameters2);
            

            BindingInfoSentinel sentinel = new BindingInfoSentinel();

            foreach (Dictionary<string, object> dictionary in testValues)
            {
                actualList.Add(sentinel.ParseDictionaryToParameters(dictionary));
            }

            for (int i = 0; i <= expectedList.Count; i++)
            {
                Assert.IsTrue(expectedList[i].arguments == actualList[i].arguments);
                Assert.IsTrue(expectedList[i].destination == actualList[i].destination);
                Assert.IsTrue(expectedList[i].destination_type == actualList[i].destination_type);
                Assert.IsTrue(expectedList[i].properties_key == actualList[i].properties_key);
                Assert.IsTrue(expectedList[i].routing_key == actualList[i].routing_key);
                Assert.IsTrue(expectedList[i].source == actualList[i].source);
                Assert.IsTrue(expectedList[i].vhost == actualList[i].source);
            }

        }
    }
}
