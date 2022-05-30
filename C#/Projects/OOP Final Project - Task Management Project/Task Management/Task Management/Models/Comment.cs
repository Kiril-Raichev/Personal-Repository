using System.Text;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    internal class Comment : IComment
    {      

        public Comment(string content, string author)
        {
            this.Content = content;
            this.Author = author;
        }



        public  string Content
        {
            get;
        }

        public string Author
        {
            get;
        }

    }
}
