using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Foo
    {
        private readonly string name;

        private Foo(string name)
        {
            this.name = name;
        }

        private async Task InitAsync()
        {
            await Task.Delay(1000);
        }

        public static async Task<Foo> CreateAsync(string name)
        {
            var result = new Foo(name);
            await result.InitAsync();
            return result;
        }
    }
}
