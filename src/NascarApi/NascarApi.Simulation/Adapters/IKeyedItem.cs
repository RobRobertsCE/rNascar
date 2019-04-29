namespace NascarApi.Simulation.Adapters
{
    public interface IKeyedItem<Key>
    {
        Key Id { get; set; }
    }
}
