namespace PrototypePattern.ExplicitDeepCopy
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    public class UserData : IPrototype<UserData>
    {
        public string[] Name;
        public Address address;

        public UserData(string[] name, Address address)
        {
            Name = name;
            this.address = address;
        }

        public UserData DeepCopy()
        {
            return new UserData((string[])Name.Clone(), address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{string.Join(" ", Name)} - {address.StreetName}, {address.HouseNumber}";
        }
    }

    public class Address : IPrototype<Address>
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}
