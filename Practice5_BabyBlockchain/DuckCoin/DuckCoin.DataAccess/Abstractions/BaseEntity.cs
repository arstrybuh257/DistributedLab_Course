namespace DuckCoin.DataAccess.Abstractions
{
    public class BaseEntity : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
