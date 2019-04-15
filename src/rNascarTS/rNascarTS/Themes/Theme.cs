using System;
using System.ComponentModel;
using System.Drawing;
using rNascarTS.Models;

namespace rNascarTS.Themes
{
    public class Theme : INotifyPropertyChanged
    {
        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region properties

        public Guid Id { get; set; }

        public ViewType ViewType { get; set; } = ViewType.All;

        public bool IsApplicationType { get; set; } = false;

        private string _name;
        public virtual string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private Color _viewForeColor;
        public virtual Color ViewForeColor
        {
            get
            {
                return _viewForeColor;
            }
            set
            {
                _viewForeColor = value;
                OnPropertyChanged(nameof(ViewForeColor));
            }
        }

        private Color _viewBackColor;
        public virtual Color ViewBackColor
        {
            get
            {
                return _viewBackColor;
            }
            set
            {
                _viewBackColor = value;
                OnPropertyChanged(nameof(ViewBackColor));
            }
        }

        private Font _viewFont;
        public virtual Font ViewFont
        {
            get
            {
                return _viewFont;
            }
            set
            {
                _viewFont = value;
                OnPropertyChanged(nameof(ViewFont));
            }
        }


        private Color _gridColumnHeaderForeColor;
        public virtual Color GridColumnHeaderForeColor
        {
            get
            {
                return _gridColumnHeaderForeColor;
            }
            set
            {
                _gridColumnHeaderForeColor = value;
                OnPropertyChanged(nameof(GridColumnHeaderForeColor));
            }
        }

        private Color _gridColumnHeaderBackColor;
        public virtual Color GridColumnHeaderBackColor
        {
            get
            {
                return _gridColumnHeaderBackColor;
            }
            set
            {
                _gridColumnHeaderBackColor = value;
                OnPropertyChanged(nameof(GridColumnHeaderBackColor));
            }
        }

        private Color _headerForeColor;
        public virtual Color HeaderForeColor
        {
            get
            {
                return _headerForeColor;
            }
            set
            {
                _headerForeColor = value;
                OnPropertyChanged(nameof(HeaderForeColor));
            }
        }

        private Color _headerBackColor;
        public virtual Color HeaderBackColor
        {
            get
            {
                return _headerBackColor;
            }
            set
            {
                _headerBackColor = value;
                OnPropertyChanged(nameof(HeaderBackColor));
            }
        }

        private Color _primaryForeColor;
        public virtual Color PrimaryForeColor
        {
            get
            {
                return _primaryForeColor;
            }
            set
            {
                _primaryForeColor = value;
                OnPropertyChanged(nameof(PrimaryForeColor));
            }
        }

        private Color _primaryBackColor;
        public virtual Color PrimaryBackColor
        {
            get
            {
                return _primaryBackColor;
            }
            set
            {
                _primaryBackColor = value;
                OnPropertyChanged(nameof(PrimaryBackColor));
            }
        }

        private Color _secondaryForeColor;
        public virtual Color SecondaryForeColor
        {
            get
            {
                return _secondaryForeColor;
            }
            set
            {
                _secondaryForeColor = value;
                OnPropertyChanged(nameof(SecondaryForeColor));
            }
        }

        private Color _secondaryBackColor;
        public virtual Color SecondaryBackColor
        {
            get
            {
                return _secondaryBackColor;
            }
            set
            {
                _secondaryBackColor = value;
                OnPropertyChanged(nameof(SecondaryBackColor));
            }
        }

        private Font _headerFont;
        public virtual Font HeaderFont
        {
            get
            {
                return _headerFont;
            }
            set
            {
                _headerFont = value;
                OnPropertyChanged(nameof(HeaderFont));
            }
        }

        private Font _gridColumnHeaderFont;
        public virtual Font GridColumnHeaderFont
        {
            get
            {
                return _gridColumnHeaderFont;
            }
            set
            {
                _gridColumnHeaderFont = value;
                OnPropertyChanged(nameof(GridColumnHeaderFont));
            }
        }

        private Font _gridFont;
        public virtual Font GridFont
        {
            get
            {
                return _gridFont;
            }
            set
            {
                _gridFont = value;
                OnPropertyChanged(nameof(GridFont));
            }
        }

        private int _borderSizeValue = 1;
        public int BorderSize
        {
            get
            {
                return _borderSizeValue;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "BorderSize",
                        value,
                        "must be >= 0");
                }

                if (_borderSizeValue != value)
                {
                    _borderSizeValue = value;
                }
            }
        }

        private Color _borderColorValue = Color.Empty;
        public Color BorderColor
        {
            get
            {
                return _borderColorValue;
            }
            set
            {
                if (value.Equals(Color.Transparent))
                {
                    throw new NotSupportedException("Transparent colors are not supported.");
                }

                if (_borderColorValue != value)
                {
                    _borderColorValue = value;
                }
            }
        }

        #endregion
    }
}