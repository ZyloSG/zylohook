using System;
using System.Collections.Generic;
using System.Text;

namespace Zylohook
{
    /* ------------------------------------------------------------------------------------- 
                                           JSONPACT V1.0
                                COPYRIGHT 2025 @ github.com/ZyloSG
    ------------------------------------------------------------------------------------- */

    public class JsonPact
    {
        private Dictionary<string, string> data;
        private string ReturnedData;

        private JsonPact()
        {
            data = new Dictionary<string, string>();
            UpdateReturnedData();
        }

        public static JsonPact CreateJson()
        {
            // Create an instance and return it
            return new JsonPact();
        }

        public void Add(string key, string value)
        {
            if (!data.ContainsKey(key))
            {
                data[key] = value;
                UpdateReturnedData();
            }
            else
            {
                Console.WriteLine($"Key \"{key}\" already exists. Use Update() if needed.");
            }
        }

        public void Update(string key, string value)
        {
            if (data.ContainsKey(key))
            {
                data[key] = value;
                UpdateReturnedData();
            }
            else
            {
                throw new NotImplementedException($"Key \"{key}\" does not exist. Use Add() to insert it.");
            }
        }

        public void Remove(string key)
        {
            if (data.Remove(key))
            {
                UpdateReturnedData();
            }
        }

        private void UpdateReturnedData()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");

            foreach (var kvp in data)
            {
                sb.Append($"\"{kvp.Key}\": \"{kvp.Value}\", ");
            }

            if (data.Count > 0)
            {
                sb.Length -= 2;
            }

            sb.Append("}");
            ReturnedData = sb.ToString();
        }

        public override string ToString()
        {
            return ReturnedData;
        }
    }
}
