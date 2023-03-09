using System;

namespace Task3
{
    class Program
    {
        enum ColourEnum
        {
            Red,
            Green,
            Blue
        }
        interface IColoured
        {
            ColourEnum Colour { get => ColourEnum.Red; }
        }
        interface IDocument
        {
            static string defaultText = "Lorem ipsum";
            int Pages { get => 0; set => Pages = value; }
            string Name { get; set; }

            void AddPages(int add)
            {
                Pages += add;
            }
            void Rename(string name)
            {
                Name = name;
            }
        }
        class ColouredDocument : IColoured, IDocument
        {
            public string Name { get; set; }
            public int Pages { get; set; }
            public ColourEnum Colour { get; set; }
            public ColouredDocument()
            {

            }
            public ColouredDocument(ColourEnum colour)
            {
                Colour = colour;
            }
        }
        class Example
        {
            public static void Do()
            {
                IDocument doc1 = new ColouredDocument { Name = "Document1" };
                Console.WriteLine(doc1.Name);
                doc1.Rename("Document2");
                Console.WriteLine(doc1.Name);
            }
        }
        static void Main(string[] args)
        {
            ColouredDocument document = new ColouredDocument();
            Console.WriteLine($"{document.Colour}{document.Name}{document.Pages}");
        }
    }
}
