using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using FeesCalculator.Model;
using AppContext = FeesCalculator.Model.AppContext;
using Type = FeesCalculator.Model.Type;

namespace FeesCalculator.ViewModel
{
    class UtilitiesViewModel : ViewModelBase
    {
        public AppContext _ctx { get; } = new AppContext();

        private ObservableCollection<Utility> _utilities;
        private Utility _selectedUtilityRow;
        private string _utilityName;
        private Type _utilityType;
        private bool _isUtilityFixed;
        private decimal _utilityValue;
        
        #region Properties

        public string UtilityName
        {
            get => _utilityName;
            set
            {
                _utilityName = value;
                RaisePropertyChanged("UtilityName");
            }
        }

        public Type UtilityType
        {
            get => _utilityType;
            set
            {
                _utilityType = value;
                RaisePropertyChanged("UtilityType");
            }
        }

        public bool IsUtilityFixed
        {
            get => _isUtilityFixed;
            set
            {
                _isUtilityFixed = value;
                RaisePropertyChanged("IsUtilityFixed");
            }
        }

        public decimal UtilityValue
        {
            get => _utilityValue;
            set
            {
                _utilityValue = value;
                RaisePropertyChanged("UtilityValue");
            }
        }
        public Array UtilityTypeComboBox
        {
            get => Enum.GetValues(typeof(Type));
        }

        public UtilitiesViewModel()
        {
            _ctx.Utilities.Load();
            Utilities = _ctx.Utilities.Local;
        }

        public ObservableCollection<Utility> Utilities
        {
            get => _utilities;
            set
            {
                _utilities = value;
                RaisePropertyChanged("Utilities");
            }
        }

        public Utility SelectedUtilityRow
        {
            get => _selectedUtilityRow;
            set
            {
                _selectedUtilityRow = value;
                RaisePropertyChanged("SelectedUtilityRow");
            }
        }
        #endregion Properties

        #region Commands
        
        //Commands for CRUD part of this window.

        private RelayCommand _addUtilityRowCommand;
        private RelayCommand _updateUtilityRowCommand;
        private RelayCommand _deleteUtilityRowCommand;
        private RelayCommand _utilityRowSelectionCommand;

        public ICommand AddUtilityRowCommand =>
            _addUtilityRowCommand ??
            (_addUtilityRowCommand = new RelayCommand(
                () =>
                {
                    _ctx.Utilities.Add(new Utility
                    {
                        Name = UtilityName,
                        Type = UtilityType,
                        IsFixed = IsUtilityFixed,
                        Value = UtilityValue
                    });
                    _ctx.SaveChanges();
                }));

        public ICommand UpdateUtilityRowCommand =>
            _updateUtilityRowCommand ??
            (_updateUtilityRowCommand = new RelayCommand(
                () =>
                {
                    SelectedUtilityRow.Name = SelectedUtilityRow.Name;
                    SelectedUtilityRow.Type = SelectedUtilityRow.Type;
                    SelectedUtilityRow.IsFixed = SelectedUtilityRow.IsFixed;
                    SelectedUtilityRow.Value = SelectedUtilityRow.Value;
                    _ctx.SaveChanges();
                }));

        public ICommand DeleteUtilityRowCommand =>
            _deleteUtilityRowCommand ??
            (_deleteUtilityRowCommand = new RelayCommand(
                () =>
                {
                    _ctx.Utilities.Remove(SelectedUtilityRow);
                    _ctx.SaveChanges();
                }));
        public ICommand UtilityRowSelectionCommand =>
            _utilityRowSelectionCommand ??
            (_utilityRowSelectionCommand =
                new RelayCommand(
                    () =>
                    {
                        UtilityName = SelectedUtilityRow.Name;
                        UtilityType = SelectedUtilityRow.Type;
                        IsUtilityFixed = SelectedUtilityRow.IsFixed;
                        UtilityValue = SelectedUtilityRow.Value;
                    },
                    () => SelectedUtilityRow != null));
    }
    #endregion
}
