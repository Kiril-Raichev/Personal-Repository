namespace Forum1.Models.Mappers
{
    public class ReactionMapper
    {
        public Reaction ConvertToModel(ReactionDto reactionDto)
        {
            Reaction reaction = new Reaction();
            reaction.Value = reactionDto.Value;
            return reaction;    
        }
    }
}
