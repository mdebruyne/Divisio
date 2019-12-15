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
    public class PostcodeGemeenteViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        PostcodeGemeenteService ObjPostcodeGemeenteService;
        public PostcodeGemeenteViewModel()
        {
            ObjPostcodeGemeenteService = new PostcodeGemeenteService();
            LoadData();
            CurrentPostcodeGemeente = new PostcodeGemeenteModel();
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
        private ObservableCollection<PostcodeGemeenteModel> postcodeGemeenteList;
        public ObservableCollection<PostcodeGemeenteModel> PostcodeGemeenteList
        {
            get { return postcodeGemeenteList; }
            set { postcodeGemeenteList = value; OnPropertyChanged("PostcodeGemeenteList"); }
        }
        private void LoadData()
        {
            PostcodeGemeenteList = new ObservableCollection<PostcodeGemeenteModel>(ObjPostcodeGemeenteService.GetAll());
        }
        #endregion

        #region SaveOperation
        private PostcodeGemeenteModel currentPostcodeGemeente;
        public PostcodeGemeenteModel CurrentPostcodeGemeente
        {
            get { return currentPostcodeGemeente; }
            set { currentPostcodeGemeente = value; OnPropertyChanged("CurrentPostcodeGemeente"); }
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
                var IsSaved = ObjPostcodeGemeenteService.Add(CurrentPostcodeGemeente);
                LoadData();
                if (IsSaved)
                    Message = "Gemeente saved.";
                else
                    Message = "Opslaan is mislukt.";
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
                var ObjPostcodeGemeente = ObjPostcodeGemeenteService.Search(CurrentPostcodeGemeente.IdGemeente);
                if (ObjPostcodeGemeente != null)
                {
                    CurrentPostcodeGemeente = ObjPostcodeGemeente;
                }
                else
                {
                    Message = "Deze gemeente niet gevonden.";
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
                var IsUpdated = ObjPostcodeGemeenteService.Update(CurrentPostcodeGemeente);
                if (IsUpdated)
                {
                    Message = "Gemeente updated";
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
                var IsDeleted = ObjPostcodeGemeenteService.Delete(CurrentPostcodeGemeente.IdGemeente);
                if (IsDeleted)
                {
                    Message = "Gemeente verwijderd.";
                    LoadData();
                }
                else
                {
                    Message = "Gemeente is niet verwijderd.";
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
