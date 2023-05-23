using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_AudioPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.ViewModel viewModel = new ViewModel.ViewModel();
        int index = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public void ClickStart(object sender, RoutedEventArgs e)
        {
            viewModel.StartMedia(index);
            Media.Play();
        }
        public void ClickPause(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }
        public void ClickNext(object sender, RoutedEventArgs e)
        {
            index++;
            if(index > viewModel.Paths.Count-1)
            {
                index = 0;
            }
            viewModel.StartMedia(index);
            Media.Play();
        }
        public void ClickPrev(object sender, RoutedEventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = viewModel.Paths.Count-1;
            }
            viewModel.StartMedia(index);
            Media.Play();
        }
        public void ClickOpenFiles(object sender, RoutedEventArgs e)
        {
            viewModel.ClearPath();
            index = 0;
            var dialog = new CommonOpenFileDialog()
            {
                IsFolderPicker = true
            };
            var res = dialog.ShowDialog();
            if (res == CommonFileDialogResult.Ok)
            {
                string[] files = Directory.GetFiles(dialog.FileName);
                foreach (string file in files)
                {
                    if (file.Contains("mp3"))
                    {
                        viewModel.AddToPath(file);
                    }
                }
                viewModel.StartMedia(index);
                Media.Play();
            }
            else
            {
                MessageBox.Show("Wrong paths");
            }
        }
    }
}
