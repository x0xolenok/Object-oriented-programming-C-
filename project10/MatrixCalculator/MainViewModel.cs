using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MatrixCalculator
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Matrix _matrixA;
        private Matrix _matrixB;
        private Matrix _matrixC;
        private bool _isAddition;
        private bool _isSubtraction;
        private bool _isMultiplication;
        private string _rowsNumMatrixA;
        private string _columnsNumMatrixA;
        private string _rowsNumMatrixB;
        private string _columnsNumMatrixB;

        public event PropertyChangedEventHandler PropertyChanged;

        public DataView MatrixA { get; set; }
        public DataView MatrixB { get; set; }
        public DataView MatrixC { get; set; }

        public ICommand CreateMatrixACommand { get; set; }
        public ICommand CreateMatrixBCommand { get; set; }
        public ICommand CalculateMatricesCommand { get; set; }

        public string RowsNumMatrixA
        {
            get { return _rowsNumMatrixA; }
            set
            {
                _rowsNumMatrixA = value;
                OnPropertyChanged(nameof(RowsNumMatrixA));
            }
        }

        public string ColumnsNumMatrixA
        {
            get { return _columnsNumMatrixA; }
            set
            {
                _columnsNumMatrixA = value;
                OnPropertyChanged(nameof(ColumnsNumMatrixA));
            }
        }

        public string RowsNumMatrixB
        {
            get { return _rowsNumMatrixB; }
            set
            {
                _rowsNumMatrixB = value;
                OnPropertyChanged(nameof(RowsNumMatrixB));
            }
        }

        public string ColumnsNumMatrixB
        {
            get { return _columnsNumMatrixB; }
            set
            {
                _columnsNumMatrixB = value;
                OnPropertyChanged(nameof(ColumnsNumMatrixB));
            }
        }

        public bool IsAddition
        {
            get { return _isAddition; }
            set
            {
                _isAddition = value;
                OnPropertyChanged(nameof(IsAddition));
            }
        }

        public bool IsSubtraction
        {
            get { return _isSubtraction; }
            set
            {
                _isSubtraction = value;
                OnPropertyChanged(nameof(IsSubtraction));
            }
        }

        public bool IsMultiplication
        {
            get { return _isMultiplication; }
            set
            {
                _isMultiplication = value;
                OnPropertyChanged(nameof(IsMultiplication));
            }
        }

        public MainViewModel()
        {
            CreateMatrixACommand = new RelayCommand(CreateMatrixA);
            CreateMatrixBCommand = new RelayCommand(CreateMatrixB);
            CalculateMatricesCommand = new RelayCommand(async () => await CalculateMatrices());
        }

        private void CreateMatrixA()
        {
            try
            {
                int rowsNum = Int32.Parse(RowsNumMatrixA);
                int columnsNum = Int32.Parse(ColumnsNumMatrixA);
                _matrixA = new Matrix(rowsNum, columnsNum);
                MatrixA = _matrixA.ToDataTable().DefaultView;
                OnPropertyChanged(nameof(MatrixA));
            }
            catch
            {
                MessageBox.Show("Некорректно введена размерность матрицы!", "Ошибка");
            }
        }

        private void CreateMatrixB()
        {
            try
            {
                int rowsNum = Int32.Parse(RowsNumMatrixB);
                int columnsNum = Int32.Parse(ColumnsNumMatrixB);
                _matrixB = new Matrix(rowsNum, columnsNum);
                MatrixB = _matrixB.ToDataTable().DefaultView;
                OnPropertyChanged(nameof(MatrixB));
            }
            catch
            {
                MessageBox.Show("Некорректно введена размерность матрицы!", "Ошибка");
            }
        }

        private async Task CalculateMatrices()
        {
            try
            {
                _matrixA = MatrixA.ToTable().ToMatrix();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы А.", "Ошибка");
                return;
            }
            try
            {
                _matrixB = MatrixB.ToTable().ToMatrix();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы B.", "Ошибка");
                return;
            }

            try
            {
                if (IsAddition)
                {
                    _matrixC = await Task.Run(() => _matrixA + _matrixB);
                }
                else if (IsSubtraction)
                {
                    _matrixC = await Task.Run(() => _matrixA - _matrixB);
                }
                else if (IsMultiplication)
                {
                    _matrixC = await Task.Run(() => _matrixA * _matrixB);
                }

                MatrixC = _matrixC.ToDataTable().DefaultView;
                OnPropertyChanged(nameof(MatrixC));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
