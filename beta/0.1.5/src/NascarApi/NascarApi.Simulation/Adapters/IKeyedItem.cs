namespace NascarApi.Mock.Adapters
{
    public interface IKeyedItem<Key>
    {
        Key Id { get; set; }
    }
}
