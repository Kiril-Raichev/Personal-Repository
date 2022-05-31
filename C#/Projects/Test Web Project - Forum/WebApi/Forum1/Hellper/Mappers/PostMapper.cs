namespace Forum1.Models.Mappers
{
    public class PostMapper
    {
        public Post ConvertToModel(PostDto dto)
        {
            Post post = new Post();
            post.Title = dto.Title;
            post.Content = dto.Content;
            return post;
        }

    }
}
