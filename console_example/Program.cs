using System;
using Newtonsoft.Json;


namespace console_example
{
    class Name
    {
        public string firstName = "John";
        public string lastName = "Doe";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var name = new Name();
            string output = JsonConvert.SerializeObject(name);
            Console.WriteLine(output); // {"firstName":"John","lastName":"Doe"}

            Name deserializedName = JsonConvert.DeserializeObject<Name>(output);
            Console.WriteLine(deserializedName.firstName); // John
            Console.WriteLine(deserializedName.lastName); // Doe
        }
    }
}
