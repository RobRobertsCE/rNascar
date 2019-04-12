using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using rNascarTimingAndScoring.Models;
using NascarFeed.Models;
using NascarFeed.Ports;

namespace rNascarTimingAndScoring.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
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

        protected IApiClient ApiClient { get; }
        
        private TSConfiguration _configuration;
        public TSConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                    _configuration = new TSConfiguration();
                return _configuration;
            }
            set
            {
                _configuration = value;
                OnPropertyChanged(nameof(Configuration));
            }
        }

        private EventSettings _eventSettings;
        public EventSettings EventSettings
        {
            get
            {
                if (_eventSettings == null)
                    _eventSettings = new EventSettings();
                return _eventSettings;
            }
            set
            {
                _eventSettings = value;
                OnPropertyChanged(nameof(EventSettings));
            }
        }

        #endregion

        #region ctor

        public ViewModelBase(IApiClient apiClient)
        {
            ApiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        #endregion

        public abstract void UpdateFeedData();
    }
}
