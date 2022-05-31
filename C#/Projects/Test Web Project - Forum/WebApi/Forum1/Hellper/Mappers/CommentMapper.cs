namespace Forum1.Models.Mappers
{
    public class CommentMapper
    {
        public Comment ConvertToComment(CommentDto commentDto)
        {
            Comment comment = new Comment();
            comment.Content = commentDto.Content;
            return comment;
        }
    }
}
