namespace Application.Commands.Create
{
    public class CreateContactOutputModel
    {
        public CreateContactOutputModel(int id)
            => this.Id = id;

        public int Id { get; }
    }
}
