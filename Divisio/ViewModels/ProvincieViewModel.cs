using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Divisio.Models;
using Divisio.Commands;
using System.Collections.ObjectModel;

namespace Divisio.ViewModels
{
    public class ProvincieViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        ProvincieService ObjProvincieService;
        public ProvincieViewModel()
        {
            ObjProvincieService = new ProvincieService();
            LoadData();
            CurrentProvincie = new ProvincieModel();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region DisplayOperation
        private ObservableCollection<ProvincieModel> provincieList;
        public ObservableCollection<ProvincieModel> ProvincieList
        {
            get { return provincieList; }
            set { provincieList = value; OnPropertyChanged("ProvincieList"); }
        }
        private void LoadData()
        {
            ProvincieList = new ObservableCollection<ProvincieModel>(ObjProvincieService.GetAll());
        }
        #endregion

        #region SaveOperation
        private ProvincieModel currentProvincie;
        public ProvincieModel CurrentProvincie
        {
            get { return currentProvincie; }
            set { currentProvincie = value; OnPropertyChanged("CurrentProvincie"); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjProvincieService.Add(CurrentProvincie);
                LoadData();
                if (IsSaved)
                    Message = "Provincie saved";
                else
                    Message = "Het opslaan is mislukt";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region SearchOperation
        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var ObjProvincie = ObjProvincieService.Search(CurrentProvincie.IdProvincie);
                if (ObjProvincie != null)
                {
                    CurrentProvincie = ObjProvincie;
                }
                else
                {
                    Message = "Deze provincie werd niet gevonden.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region UpdateOperation
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjProvincieService.Update(CurrentProvincie);
                if (IsUpdated)
                {
                    Message = "Provincie updated.";
                    LoadData();
                }
                else
                {
                    Message = "Updaten is mislukt.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DeleteOperation
        private RelayCommand deleteCommand;



        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var IsDeleted = ObjProvincieService.Delete(CurrentProvincie.IdProvincie);
                if (IsDeleted)
                {
                    Message = "Provincie deleted";
                    LoadData();
                }
                else
                {
                    Message = "Provincie verwijderen is mislukt.";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}
