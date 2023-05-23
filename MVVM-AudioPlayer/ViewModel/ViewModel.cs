using MVVM_AudioPlayer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MVVM_AudioPlayer.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        MediaModel MediaModel;
        public ViewModel()
        {
            MediaModel = new MediaModel();
        }

        public ObservableCollection<string> Paths
        {
            get
            {
                return MediaModel.paths;
            }
            set
            {
                if(value != MediaModel.paths)
                {
                    MediaModel.paths = value;
                    OnPropertyChanged("Paths");
                }
            }
        }

        public Uri MediaPath
        {
            get
            {
                return MediaModel.MediaPath;
            }
            set
            {
                if(MediaModel.MediaPath != value)
                {
                    MediaModel.MediaPath = value;
                    OnPropertyChanged("MediaPath");
                }
            }
        }

        public void AddToPath(string path)
        {
            Paths.Add(path);
            OnPropertyChanged("Paths");
        }

        public void StartMedia(int index)
        {
            try
            {
                if (Paths[index] != null)
                {
                    MediaPath = new Uri(Paths[index]);
                    var a = MediaPath.ToString().Split("/");
                    ChangeName(a[a.Length - 1]);
                    OnPropertyChanged("MediaPath");
                }
            }
            catch { MessageBox.Show("No paths"); }
        }

        public void ClearPath()
        {
            Paths.Clear();
            OnPropertyChanged("Paths");
        }

        public void ChangeName(string name)
        {
            Name = name;
            OnPropertyChanged("Name");
        }

        public string Name
        {
            get
            {
                return MediaModel.Name;
            }
            set
            {
                if(value != MediaModel.Name)
                {
                    MediaModel.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
