using Bogus;

namespace TaskManagement.UnitTest
{
    internal abstract class BaseBuilder <T>
    {
        protected Faker Faker = new("pt_BR");
        public abstract T BuildObject();

    }
}
