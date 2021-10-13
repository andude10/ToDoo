using System;
using System.ComponentModel;
using SQLite;

namespace ToDoo.Models
{
    public class Case : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        private bool _isReady;
        public bool IsReady 
        {
            get
            {
                return _isReady;
            }
            set
            {
                _isReady = value;
                OnPropertyChanged(nameof(IsReady));
            } 
        }
        public DateTime Date { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
