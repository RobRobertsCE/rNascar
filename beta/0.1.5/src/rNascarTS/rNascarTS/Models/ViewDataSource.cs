using System.Collections.Generic;

namespace rNascarTS.Models
{
    public class ViewDataSource
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string AssemblyQualifiedName { get; set; }
        public IList<ViewDataSource> Lists { get; set; } = new List<ViewDataSource>();
        public IList<ViewDataSource> NestedClasses { get; set; } = new List<ViewDataSource>();
        public IList<ViewDataMember> Fields { get; set; } = new List<ViewDataMember>();

        public override string ToString()
        {
            return $"{Type} - {Name}";
        }
    }
}
