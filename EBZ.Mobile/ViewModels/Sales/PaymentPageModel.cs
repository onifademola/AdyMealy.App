using EBZ.Mobile.Models;
using EBZ.Mobile.Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace EBZ.Mobile.ViewModels.Sales
{
    [Preserve(AllMembers = true)]
    public class PaymentPageModel : INotifyPropertyChanged
    {
        #region Fields
        private string _departmentName;
        private string _email;
        private string _firstName;
        private string _lastName;
        private double _inputQuantity;
        private double _inputAmount;
        private string _mealEntitledPerDay;
        private string _inputCustomerPin;
        private string _inputSalesPinVerify;
        private string _inputCustomerPinVerify;
        private string _inputSalesPinVerifyColor;
        private string _inputCustomerPinVerifyColor;
        private bool _isSalesPinEnabled;
        private bool _isCustomerPinEnabled;
        private bool _isPayBtnEnabled;
        private bool _isBuyInputEnabled;
        private AspUser _aspUser;
        #endregion

        #region Constructor
        //DateModel _dateModel = new DateModel();
        DialogService _dialogService = new DialogService();
        SalesDataService _salesDataService = new SalesDataService();

        public PaymentPageModel()
        {
            this.PayCommand = new Command(this.PayCommandClicked);
            InitializeData();
        }

        #endregion


        #region Property

        public AspUser aspUser
        {
            get { return this._aspUser; }
            set
            {
                if (this._aspUser == value)
                {
                    return;
                }
                this._aspUser = value;
                this.OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public string DepartmentName
        {
            get { return this._departmentName; }
            set
            {
                if (this._departmentName == value)
                {
                    return;
                }
                this._departmentName = value;
                this.OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get { return this._firstName; }
            set
            {
                if (this._firstName == value)
                {
                    return;
                }
                this._firstName = value;
                this.OnPropertyChanged();
            }
        }

        public string LastName
        {
            get { return this._lastName; }
            set
            {
                if (this._lastName == value)
                {
                    return;
                }
                this._lastName = value;
                this.OnPropertyChanged();
            }
        }
        
        public string MealEntitledPerDay
        {
            get { return this._mealEntitledPerDay; }
            set
            {
                if (this._mealEntitledPerDay == value)
                {
                    return;
                }
                this._mealEntitledPerDay = value;
                this.OnPropertyChanged();
            }
        }
        public string InputCustomerPin
        {
            get { return this._inputCustomerPin; }
            set
            {
                if (this._inputCustomerPin == value)
                {
                    return;
                }
                this._inputCustomerPin = value;
                this.OnPropertyChanged();
                CustomerPinValidation();
            }
        }

        public string InputSalesPinVerify
        {
            get { return this._inputSalesPinVerify; }
            set
            {
                if (this._inputSalesPinVerify == value)
                {
                    return;
                }
                this._inputSalesPinVerify = value;
                this.OnPropertyChanged();
            }
        }

        public string InputCustomerPinVerify
        {
            get { return this._inputCustomerPinVerify; }
            set
            {
                if (this._inputCustomerPinVerify == value)
                {
                    return;
                }
                this._inputCustomerPinVerify = value;
                this.OnPropertyChanged();
            }
        }

        public string InputSalesPinVerifyColor
        {
            get { return this._inputSalesPinVerifyColor; }
            set
            {
                if (this._inputSalesPinVerifyColor == value)
                {
                    return;
                }
                this._inputSalesPinVerifyColor = value;
                this.OnPropertyChanged();
            }
        }

        public string InputCustomerPinVerifyColor
        {
            get { return this._inputCustomerPinVerifyColor; }
            set
            {
                if (this._inputCustomerPinVerifyColor == value)
                {
                    return;
                }
                this._inputCustomerPinVerifyColor = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsSalesPinEnabled
        {
            get { return this._isSalesPinEnabled; }
            set
            {
                if (this._isSalesPinEnabled == value)
                {
                    return;
                }
                this._isSalesPinEnabled = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsCustomerPinEnabled
        {
            get { return this._isCustomerPinEnabled; }
            set
            {
                if (this._isCustomerPinEnabled == value)
                {
                    return;
                }
                this._isCustomerPinEnabled = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsPayBtnEnabled
        {
            get { return this._isPayBtnEnabled; }
            set
            {
                if(this._isPayBtnEnabled == value)
                {
                    return;
                }
                this._isPayBtnEnabled = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsBuyInputEnabled
        {
            get { return this._isBuyInputEnabled; }
            set
            {
                if(this._isBuyInputEnabled == value)
                {
                    return;
                }
                this._isBuyInputEnabled = value;
                this.OnPropertyChanged();
            }
        }
        #endregion

        #region Command
        public Command PayCommand { get; set; }
        #endregion

        #region Methods
        
        public async void SalesPinValidation()
        {
            //check if pin length is upto 4 characters
            if (this.MealEntitledPerDay != null && this.MealEntitledPerDay.Length == 4)
            {
                //start to verify pin
                _dialogService.ShowLoading("Verifying...");
                var result = await _salesDataService.ValidateSalesPin(this.MealEntitledPerDay);
                if (result != null)
                {
                    _dialogService.HideLoading();
                    this.InputSalesPinVerifyColor = "Green";
                    this.InputSalesPinVerify = "Verified";
                    IsSalesPinEnabled = false;
                    IsBuyInputEnabled = false;
                    IsCustomerPinEnabled = true;
                }
                else
                {
                    _dialogService.HideLoading();
                    _dialogService.ShowToast("Sorry! Sales PIN is NOT correct. Please try again.");
                }
            }
        }

        public async void CustomerPinValidation()
        {
            //check if pin length is upto 4 characters
            if (this.InputCustomerPin != null && this.InputCustomerPin.Length == 4)
            {
                //start to verify pin
                _dialogService.ShowLoading("Verifying...");
                var result = await _salesDataService.ValidateCustomersPin(DepartmentName, this.InputCustomerPin);
                if (result != null)
                {
                    _dialogService.HideLoading();
                    this.InputCustomerPinVerifyColor = "Green";
                    this.InputCustomerPinVerify = "Verified";
                    IsCustomerPinEnabled = false;
                    IsPayBtnEnabled = true;
                }
                else
                {
                    _dialogService.HideLoading();
                    _dialogService.ShowToast("Sorry! Customer PIN is NOT correct. Please try again.");
                }
            }
        }

        private void InitializeData()
        {
            this.InputSalesPinVerifyColor = "White";
            this.InputSalesPinVerify = "Unverified";
            this.InputCustomerPinVerifyColor = "Red";           
            this.InputCustomerPinVerify = "Unverified";

            IsCustomerPinEnabled = false;
            IsSalesPinEnabled = false;
            IsPayBtnEnabled = false;
            IsBuyInputEnabled = true;

            if (Application.Current.Properties.ContainsKey("checkinCust"))
            {
                _aspUser = (AspUser)Application.Current.Properties["checkinCust"];

                Application.Current.Properties["checkinCust"] = null;

                this.DepartmentName = _aspUser.DepartmentName;
                this.Email = _aspUser.Email;
                this.FirstName = _aspUser.FirstName;
                this.LastName = _aspUser.LastName;
                this.MealEntitledPerDay = _aspUser.MealEntitledPerDay.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void PayCommandClicked(object obj)
        {
            var navServ = App.ViewNavigationService;
            _dialogService.ShowLoading("Queuing...");
            var result = await _salesDataService.QueueUser(_aspUser.Id);
            if (result == null)
            {
                _dialogService.HideLoading();
                _dialogService.ShowToast("Sorry! User not queued.");
                this.InputSalesPinVerifyColor = "Red";
                return;

            }
            _dialogService.HideLoading();
            _dialogService.ShowToast("User queued successfully.");
            await navServ.GoBack();
        }
        #endregion
    }
}