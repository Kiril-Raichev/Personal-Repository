namespace MoqProject.Services
{
    public interface ILoginInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public userRole Role { get; set; }
    }

    public enum userRole
    {
        Anon,
        User,
        Admin
    } 

    public interface Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
    }
}
