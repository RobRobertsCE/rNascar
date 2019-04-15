using System;
using rNascarTS.Models;

namespace rNascarTS.Settings
{
    public class ViewState
    {
        private Guid _id;
        public Guid Id
        {
            get
            {
                if (_id == null || _id == Guid.Empty)
                    _id = Guid.NewGuid();

                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string Name { get; set; }
        public string HeaderText { get; set; }
        public string Description { get; set; }
        public int Index { get; set; }
        public ViewType ViewType { get; set; }
        public ViewCellPosition CellPosition { get; set; } = new ViewCellPosition();
        public ViewListSettings ListSettings { get; set; } = new ViewListSettings();
        public Guid ThemeId { get; set; }
        public bool IsDisplayed { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
