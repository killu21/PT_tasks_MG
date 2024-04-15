namespace Task1
{
    public class Book : Item
    {
        public Book(string name)
        {
            Name = name;
        }

        public override string Name { get; }
    }
}