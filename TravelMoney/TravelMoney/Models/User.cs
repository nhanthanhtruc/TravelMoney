using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TravelMoney.Models
{
    public partial class User : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }
        private Boolean _Female;
        public Boolean Female
        {
            get => _Female;
            set
            {
                if (_Female != value)
                {
                    _Female = value;
                    RaisePropertyChanged(nameof(Female));
                }
            }
        }
        private string _Image;
        public string Image
        {
            get => _Image;
            set
            {
                if (_Image != value)
                {
                    _Image = value;
                    RaisePropertyChanged(nameof(Image));
                }
            }
        }
        private string _Email;
        public string Email
        {
            get => _Email;
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    RaisePropertyChanged(nameof(Email));
                }
            }
        }
        private Boolean _Online;
        public Boolean Online
        {
            get => _Online;
            set
            {
                if (_Online != value)
                {
                    _Online = value;
                    RaisePropertyChanged(nameof(Online));
                }
            }
        }
        private Boolean _Default;
        public Boolean Default
        {
            get => _Default;
            set
            {
                if (_Default != value)
                {
                    _Default = value;
                    RaisePropertyChanged(nameof(Default));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string PropertyName)
        {
            //if (PropertyChanged != null)
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        
    }
}
