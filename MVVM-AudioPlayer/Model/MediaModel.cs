using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MVVM_AudioPlayer.Model
{
    public class MediaModel
    {
        public ObservableCollection<string> paths = new ObservableCollection<string>();
        public Uri MediaPath;
        public string Name;
    }
}
