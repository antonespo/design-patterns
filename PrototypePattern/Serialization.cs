using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern.Serialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }
    }

    [Serializable]
    public class UserData
    {
        public string[] Name;
        public Address address;

        public UserData(string[] name, Address address)
        {
            Name = name;
            this.address = address;
        }

        public override string ToString()
        {
            return $"{string.Join(" ", Name)} - {address.StreetName}, {address.HouseNumber}";
        }
    }

    [Serializable]
    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }
}
