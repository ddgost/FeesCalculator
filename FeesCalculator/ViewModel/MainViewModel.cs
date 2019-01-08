using System;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using FeesCalculator.Model;
using AppContext = FeesCalculator.Model.AppContext;
using Type = FeesCalculator.Model.Type;

namespace FeesCalculator.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        #region Fields
        private readonly AppContext _ctx = new AppContext();
        private readonly decimal _vat = 1.23m;
        private string _datePickerSelection;
        private int _numberofPeople;
        private decimal _coFixedValue;
        private decimal _trashValue;
        private decimal _zwCurrentValue;
        private decimal _zwLastMonth;
        private decimal _zwChange;
        private decimal _zwPerPerson;
        private decimal _cwCurrentValue;
        private decimal _cwLastMonth;
        private decimal _cwChange;
        private decimal _cwPerPerson;
        private decimal _coCurrentValue;
        private decimal _coLastMonth;
        private decimal _coChange;
        private decimal _coPerPerson;
        private decimal _elecCurrentValue;
        private decimal _elecLastMonth;
        private decimal _elecChange;
        private decimal _elecPerPerson;
        #endregion Fields

        #region Properties
        public string DatePickerSelection
        {
            get => _datePickerSelection; 
            set
            {
                _datePickerSelection = value;
                RaisePropertyChanged("DatePickerSelection");
            }
        }

        public int NumberofPeople
        {
            get => _numberofPeople;
            set
            {
                _numberofPeople = value;
                RaisePropertyChanged("NumberofPeople");
            }

        }

        public decimal CoFixedValue
        {
            get => _coFixedValue;
            set
            {
                _coFixedValue = value;
                RaisePropertyChanged("CoFixedValue");
            }
        }

        public decimal TrashValue
        {
            get => _trashValue;
            set
            {
                _trashValue = value;
                RaisePropertyChanged("TrashValue");
            }
        }

        public decimal ZwCurrentValue
        {
            get => _zwCurrentValue;
            set
            {
                _zwCurrentValue = value;
                RaisePropertyChanged("ZwCurrentValue");
                ZwChange = ZwCurrentValue - ZwLastMonth;
            }
        }

        public decimal ZwLastMonth
        {
            get => _zwLastMonth;
            set
            {
                _zwLastMonth = value;
                RaisePropertyChanged("ZwLastMonth");
            }
        }

        public decimal ZwChange
        {
            get => _zwChange;
            set
            {
                _zwChange = value;
                RaisePropertyChanged("ZwChange");
            }
        }

        public decimal ZwPerPerson
        {
            get => _zwPerPerson;
            set
            {
                _zwPerPerson = value;
                RaisePropertyChanged("ZwPerPerson");
            }
        }

        public decimal CwCurrentValue
        {
            get => _cwCurrentValue;
            set
            {
                _cwCurrentValue = value;
                RaisePropertyChanged("CwCurrentValue");
                CwChange = CwCurrentValue - CwLastMonth;
            }
        }

        public decimal CwLastMonth
        {
            get => _cwLastMonth;
            set
            {
                _cwLastMonth = value;
                RaisePropertyChanged("CwLastMonth");
            }
        }

        public decimal CwChange
        {
            get => _cwChange;
            set
            {
                _cwChange = value;
                RaisePropertyChanged("CwChange");
            }
        }

        public decimal CwPerPerson
        {
            get => _cwPerPerson;
            set
            {
                _cwPerPerson = value;
                RaisePropertyChanged("CwPerPerson");
            }
        }

        public decimal COCurrentValue
        {
            get => _coCurrentValue;
            set
            {
                _coCurrentValue = value;
                RaisePropertyChanged("COCurrentValue");
                COChange = COCurrentValue - COLastMonth;
            }
        }

        public decimal COLastMonth
        {
            get => _coLastMonth;
            set
            {
                _coLastMonth = value;
                RaisePropertyChanged("COLastMonth");
            }
        }

        public decimal COChange
        {
            get => _coChange;
            set
            {
                _coChange = value;
                RaisePropertyChanged("COChange");
            }
        }

        public decimal COPerPerson
        {
            get => _coPerPerson;
            set
            {
                _coPerPerson = value;
                RaisePropertyChanged("COPerPerson");
            }
        }

        public decimal ElecCurrentValue
        {
            get => _elecCurrentValue;
            set
            {
                _elecCurrentValue = value;
                RaisePropertyChanged("ElecCurrentValue");
                ElecChange = ElecCurrentValue - ElecLastMonth;
            }
        }

        public decimal ElecLastMonth
        {
            get => _elecLastMonth;
            set
            {
                _elecLastMonth = value;
                RaisePropertyChanged("ElecLastMonth");
            }
        }

        public decimal ElecChange
        {
            get => _elecChange;
            set
            {
                _elecChange = value;
                RaisePropertyChanged("ElecChange");
            }
        }

        public decimal ElecPerPerson
        {
            get => _elecPerPerson;
            set
            {
                _elecPerPerson = value;
                RaisePropertyChanged("ElecPerPerson");
            }
        }
        private decimal _otherCurrentValue;
        public decimal OtherCurrentValue
        {
            get => _otherCurrentValue;
            set
            {
                _otherCurrentValue = value;
                RaisePropertyChanged("OtherCurrentValue");
            }
        }
        private decimal _otherPerPerson;
        public decimal OtherPerPerson
        {
            get => _otherPerPerson;
            set
            {
                _otherPerPerson = value;
                RaisePropertyChanged("OtherPerPerson");
            }
        }

        private decimal _sumPerPerson;

        public decimal SumPerPerson
        {
            get => _sumPerPerson;
            set
            {
                _sumPerPerson = value;
                RaisePropertyChanged("SumPerPerson");
            }
        }
        #endregion Properties

        #region Methods
        // Getting selected date from Datepicker to use for _previousMonth method and saving calculated set to db.
        private string _selectedMonth(string DatePickerSelection)
        {
            var selectedMonth = DateTime.Parse(DatePickerSelection);
            return selectedMonth.ToString("MMMM yyyy");
        }
        // For methods that needs name of previous month selected in DatePicker, for Db query purposes.
        private string _previousMonth(string SelectedMonth)
        {
            var previousMonth = DateTime.Parse(SelectedMonth);
            return previousMonth.AddMonths(-1).ToString("MMMM yyyy"); 
        }

        private void _getCoFixedValueFromDB()
        {
            var q = _ctx.Utilities
                .Where(a => a.Name == "Centralne ogrzewanie - opłata stała")
                .Select(a => a.Value).SingleOrDefault();
            CoFixedValue = q;

        }
        private void _getTrashValueFromDB()
        {
            var r = _ctx.Utilities
                .Where(b => b.Name == "Wywóz nieczystości")
                .Select(b => b.Value).SingleOrDefault();
            TrashValue = r;

        }

        private void _fillPreviousMonthConsumptionTextBoxes()
        {
            string month = _previousMonth(DatePickerSelection);
            var q = _ctx.MonthlyConsumptions
                .Where(a => a.NameofMonth == month)
                .ToList();
            foreach (var a in q)
            {
                CwLastMonth = a.CwCurrentValue;
                ZwLastMonth = a.ZwCurrentValue;
                COLastMonth = a.COCurrentValue;
                ElecLastMonth = a.ElecCurrentValue;
            }
        }

        private void _resetAllTextBoxes()
        {
            NumberofPeople = 0;
            CoFixedValue = 0m;
            TrashValue = 0m;
            CwCurrentValue = 0;
            CwLastMonth = 0m;
            CwChange = 0m;
            CwPerPerson = 0m;
            ZwCurrentValue = 0;
            ZwLastMonth = 0m;
            ZwChange = 0m;
            ZwPerPerson = 0m;
            COCurrentValue = 0;
            COLastMonth = 0m;
            COChange = 0m;
            COPerPerson = 0m;
            ElecCurrentValue = 0;
            ElecLastMonth = 0m;
            ElecChange = 0m;
            ElecPerPerson = 0m;
            OtherPerPerson = 0m;
            OtherCurrentValue = 0m;
            SumPerPerson = 0m;

        }

        private void _fillAllTextBoxesFromDB()
        {
            string month = _selectedMonth(DatePickerSelection);
            var q = _ctx.MonthlyConsumptions
                .Where(a => a.NameofMonth == month)
                .ToList();
            foreach (var a in q)
            {
                NumberofPeople = a.NumberofPeople;
                CwCurrentValue = a.CwCurrentValue;
                CwChange = a.CwChange;
                CwPerPerson = a.CwPerPerson;
                ZwCurrentValue = a.ZwCurrentValue;
                ZwChange = a.ZwChange;
                ZwPerPerson = a.ZwPerPerson;
                COCurrentValue = a.COCurrentValue;
                COChange = a.COChange;
                COPerPerson = a.COPerPerson;
                ElecCurrentValue = a.ElecCurrentValue;
                ElecChange = a.ElecChange;
                ElecPerPerson = a.ElecPerPerson;
                OtherCurrentValue = a.OtherCurrentValue;
                OtherPerPerson = a.OtherPerPerson;
                SumPerPerson = a.SumPerPerson;
            }
            _fillPreviousMonthConsumptionTextBoxes();
        }
        #endregion Methods

        #region Commands
        private RelayCommand _newBillingPeriodCommand;
        private RelayCommand _loadExistingBillingPeriodCommand;
        private RelayCommand _showUtilityWindowCommand;
        private RelayCommand _calculateCommand;
        private RelayCommand _saveCommand;

        public ICommand NewBillingPeriodCommand =>
            _newBillingPeriodCommand ??
            (_newBillingPeriodCommand = new RelayCommand(
                () =>
                {
                    _resetAllTextBoxes();
                    _getCoFixedValueFromDB();
                    _getTrashValueFromDB();
                    _fillPreviousMonthConsumptionTextBoxes();
                }));

        public ICommand LoadExistingBillingPeriodCommand =>
            _loadExistingBillingPeriodCommand ??
            (_loadExistingBillingPeriodCommand = new RelayCommand(
                () =>
                {
                    _resetAllTextBoxes();
                    _getCoFixedValueFromDB();
                    _getTrashValueFromDB();
                    _fillAllTextBoxesFromDB();
                }));

        //Rest of login in MainWindow codebehind.
        public ICommand ShowUtilityWindowCommand =>
            _showUtilityWindowCommand ??
            (_showUtilityWindowCommand = new RelayCommand(
                () =>
                {
                    Messenger.Default.Send(new NotificationMessage("ShowUtilityWindow"));
                }));
        //Main command for whole project. Zw is in fact sum of drawn cold water and sewage from hot water. 
        public ICommand CalculateCommand =>
            _calculateCommand ??
            (_calculateCommand = new RelayCommand(
                () =>
                {
                    var cwquery = _ctx.Utilities
                        .Where(a => a.Type == Type.Cw)
                        .Where(a => a.IsFixed == false)
                        .Select(a => a.Value).SingleOrDefault();
                    CwPerPerson = (CwChange * cwquery) / NumberofPeople;
                    var zwquery = _ctx.Utilities
                        .Where(a => a.Type == Type.Zw)
                        .Where(a => a.IsFixed == false)
                        .Select(a => a.Value).SingleOrDefault();
                    ZwPerPerson = ((CwChange + ZwChange)* zwquery) / NumberofPeople;
                    if (COChange == 0m)
                    {
                        COPerPerson = 0m;
                    }
                    else
                    {
                        var coquery = _ctx.Utilities
                            .Where(a => a.Type == Type.CO)
                            .Where(a => a.IsFixed == false)
                            .Select(a => a.Value).SingleOrDefault();
                        COPerPerson = (COChange * coquery) / NumberofPeople;
                    }
                    var elecfixedquery = _ctx.Utilities
                        .Where(a => a.Type == Type.Elec)
                        .Where(a => a.IsFixed == true)
                        .Select(a => a.Value).ToList();

                    var elecvariablequery = _ctx.Utilities
                        .Where(a => a.Type == Type.Elec)
                        .Where(a => a.IsFixed == false)
                        .Select(a => a.Value).ToList();
                    foreach (var element in elecvariablequery)
                    {
                        ElecPerPerson += element * ElecChange;
                    }

                    ElecPerPerson = (ElecPerPerson + elecfixedquery.Sum())*_vat / NumberofPeople;
                    OtherPerPerson = OtherCurrentValue / NumberofPeople;
                    SumPerPerson = (CoFixedValue + TrashValue) / NumberofPeople + CwPerPerson + ZwPerPerson + COPerPerson + ElecPerPerson + OtherPerPerson;
                }));
        //Save values calculated in CalculateCommand to Db.
        public ICommand SaveCommand =>
            _saveCommand ??
            (_saveCommand = new RelayCommand(
                () =>
                {
                    _ctx.MonthlyConsumptions.Add(new MonthlyConsumption
                        {
                            NameofMonth = _selectedMonth(DatePickerSelection),
                            NumberofPeople = NumberofPeople,
                            CwCurrentValue = CwCurrentValue,
                            CwChange = CwChange,
                            CwPerPerson = CwPerPerson,
                            ZwCurrentValue = ZwCurrentValue,
                            ZwChange = ZwChange,
                            ZwPerPerson = ZwPerPerson,
                            COCurrentValue = COCurrentValue,
                            COChange = COChange,
                            COPerPerson = COPerPerson,
                            ElecCurrentValue = ElecCurrentValue,
                            ElecChange = ElecChange,
                            ElecPerPerson = ElecPerPerson,
                            OtherCurrentValue = OtherCurrentValue,
                            OtherPerPerson = OtherPerPerson,
                            SumPerPerson = SumPerPerson
                        });
                    _ctx.SaveChanges();
                }));
        #endregion Commands
    }
}
