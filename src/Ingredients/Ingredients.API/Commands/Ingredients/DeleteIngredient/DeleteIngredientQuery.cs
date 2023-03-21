using MediatR;

namespace src.Ingredients.Ingredients.API.Commands.Ingredients.DeleteIngredient
{
    public class DeleteIngredientQuery : IRequest
    {
        public DeleteIngredientQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
