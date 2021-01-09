using System;

namespace PrototypePattern
{
    public class UserData
    {
        public string[] Name;
        public Address address;

        public UserData(UserData other)
        {
            Name = (string[])other.Name.Clone();
            address = new Address(other.address);
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

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new UserData(new[] { "Antonio", "Esposito" }, new Address("Via San Francesco", 15));
            var user2 = new UserData(user1);
            user2.Name[0] = "Maria";
            user2.address.HouseNumber = 35;
            Console.WriteLine(user1);
            Console.WriteLine(user2);

        }
    }
}
