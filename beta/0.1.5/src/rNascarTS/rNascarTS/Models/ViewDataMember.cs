namespace rNascarTS.Models
{
    public class ViewDataMember
    {
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Type} - {Name}";
        }
    }
}
