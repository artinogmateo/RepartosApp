using System.ComponentModel;

namespace Repartos.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyname));
        }
    }
}

