using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MedExpertClientClone.Models;
using Xamarin.Forms;

namespace MedExpertClientClone.ViewModels.Audits
{
    public class FileManager : INotifyPropertyChanged
    {
        #region Fields

        private string fileName;
        private AnswerType answerType;
        private ImageSource imageIcon;
        private ObservableCollection<FileManager> subFiles;

        #endregion

        #region Constructor
        public FileManager()
        {
        }

        #endregion

        #region Properties
        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                OnPropertyChanged("SubFiles");
            }
        }

        public string ItemName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FolderName");
            }
        }
        public ImageSource ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                OnPropertyChanged("ImageIcon");
            }
        }

        public AnswerType AnswerType
        {
            get { return answerType; }
            set
            {
                answerType = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}