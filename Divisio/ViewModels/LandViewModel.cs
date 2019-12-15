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
    class LandViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        LandService ObjLandService;
        public LandViewModel()
        {
            ObjLandService = new LandService();
            LoadData();
            CurrentLand = new LandModel();
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
        private ObservableCollection<LandModel> landList;
        public ObservableCollection<LandModel> LandList
        {
            get { return landList; }
            set { landList = value; OnPropertyChanged("LandList"); }
        }
        private void LoadData()
        {
            LandList = new ObservableCollection<LandModel>(ObjLandService.GetAll());
        }
        #endregion

        #region SaveOperation
        private LandModel currentLand;
        public LandModel CurrentLand
        {
            get { return currentLand; }
            set { currentLand = value; OnPropertyChanged("CurrentLand"); }
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
                var IsSaved = ObjLandService.Add(CurrentLand);
                LoadData();
                if (IsSaved)
                    Message = "Land saved";
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
                var ObjLand = ObjLandService.Search(CurrentLand.IdLand);
                if (ObjLand != null)
                {
                    CurrentLand = ObjLand;
                }
                else
                {
                    Message = "Dit land werd niet gevonden.";
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
                var IsUpdated = ObjLandService.Update(CurrentLand);
                if (IsUpdated)
                {
                    Message = "Land updated.";
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
                var IsDeleted = ObjLandService.Delete(CurrentLand.IdLand);
                if (IsDeleted)
                {
                    Message = "Land deleted";
                    LoadData();
                }
                else
                {
                    Message = "Land verwijderen is mislukt.";
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
