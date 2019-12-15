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
    public class UserViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        UserService ObjUserService;
        
        public UserViewModel()
        {
            ObjUserService = new UserService();
            LoadData();
            CurrentUser = new UserModel();
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
        private ObservableCollection<UserModel> userList;
        public ObservableCollection<UserModel> UserList
        {
            get { return userList; }
            set { userList = value; OnPropertyChanged("UserList"); }
        }
        private void LoadData()
        {
            UserList = new ObservableCollection<UserModel>(ObjUserService.GetAll());
        }
        #endregion

        #region SaveOperation
        private UserModel currentUser;
        public UserModel CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
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
                var IsSaved = ObjUserService.Add(CurrentUser);
                LoadData();
                if (IsSaved)
                    Message = "Account saved";
                else
                    Message = "Save operation failed";
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
                var ObjUser = ObjUserService.Search(CurrentUser.IdUser);
                if (ObjUser != null)
                {
                    CurrentUser = ObjUser;
                }
                else
                {
                    Message = "User niet gevonden.";
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
                var IsUpdated = ObjUserService.Update(CurrentUser);
                if (IsUpdated)
                {
                    Message = "User updated";
                    LoadData();
                }
                else
                {
                    Message = "Update niet gelukt";
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
                var IsDeleted = ObjUserService.Delete(CurrentUser.IdUser);
                if (IsDeleted)
                {
                    Message = "User verwijderd";
                    LoadData();
                }
                else
                {
                    Message = "Mislukt. User niet verwijderd";
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
