using System.IO;
using System.Xml.Serialization;

namespace PrototypePattern.Serialization
{
    public static class ExtensionMethods
    {
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }

    public class UserData
    {
        public string[] Name;
        public Address address;

        public UserData()
        {
        }

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

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address()
        {
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }
}
