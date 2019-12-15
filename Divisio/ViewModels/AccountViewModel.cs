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
    public class AccountViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        AccountService ObjAccountService;
        public AccountViewModel()
        {
            ObjAccountService = new AccountService();
            LoadData();
            CurrentAccount = new AccountModel();
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
        private ObservableCollection<AccountModel> accountList;
        public ObservableCollection<AccountModel> AccountList
        {
            get { return accountList; }
            set { accountList = value; OnPropertyChanged("AccountList"); }
        }
        private void LoadData()
        {
            AccountList = new ObservableCollection<AccountModel>(ObjAccountService.GetAll());
        }
        #endregion

        #region SaveOperation
        private AccountModel currentAccount;
        public AccountModel CurrentAccount
        {
            get { return currentAccount; }
            set { currentAccount = value; OnPropertyChanged("CurrentAccount"); }
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
                var IsSaved = ObjAccountService.Add(CurrentAccount);
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
                var ObjAccount = ObjAccountService.Search(CurrentAccount.IdAccount);
                if (ObjAccount != null)
                {
                    CurrentAccount = ObjAccount;
                }
                else
                {
                    Message = "Account not found";
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
                var IsUpdated = ObjAccountService.Update(CurrentAccount);
                if (IsUpdated)
                {
                    Message = "Account updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed";
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
                var IsDeleted = ObjAccountService.Delete(CurrentAccount.IdAccount);
                if (IsDeleted)
                {
                    Message = "Account deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
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
