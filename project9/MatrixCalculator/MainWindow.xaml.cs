using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MatrixCalculator
{
    public partial class MainWindow : Window
    {
        Matrix _matrixA;
        Matrix _matrixB;
        Matrix _matrixC;

        enum Operations
        {
            Addition,
            Subtraction,
            Multiplication
        }

        public MainWindow()
        {
            InitializeComponent();
            _matrixA = null;
            _matrixB = null;
            _matrixC = null;
        }

        private void CreateAndSetMatrix(ref Matrix matrix, DataGrid dataGrid, TextBox textBoxRowsNum, TextBox textBoxColumnsNum)
        {
            try
            {
                int rowsNum = Int32.Parse(textBoxRowsNum.Text);
                int columnsNum = Int32.Parse(textBoxColumnsNum.Text);
                matrix = new Matrix(rowsNum, columnsNum);
                DataTable dataTable = matrix.ToDataTable();
                dataGrid.DataContext = dataTable.DefaultView;
            }
            catch
            {
                MessageBox.Show("Некорректно введена размерность матрицы!", "Ошибка");
            }
        }

        private Matrix GetMatrixFromDataGrid(DataGrid dataGrid)
        {
            return ((DataView)dataGrid.ItemsSource).ToTable().ToMatrix();
        }

        private async Task CalculateMatricesAndSetResultAsync(Operations operation)
        {
            try
            {
                _matrixA = GetMatrixFromDataGrid(DataGridMatrixA);
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
                _matrixB = GetMatrixFromDataGrid(DataGridMatrixB);
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
                switch (operation)
                {
                    case Operations.Addition:
                        _matrixC = await Task.Run(() => _matrixA + _matrixB);
                        DataGridMatrixC.DataContext = _matrixC.ToDataTable().DefaultView;
                        break;
                    case Operations.Subtraction:
                        _matrixC = await Task.Run(() => _matrixA - _matrixB);
                        DataGridMatrixC2.DataContext = _matrixC.ToDataTable().DefaultView;
                        break;
                    case Operations.Multiplication:
                        _matrixC = await Task.Run(() => _matrixA * _matrixB);
                        DataGridMatrixC3.DataContext = _matrixC.ToDataTable().DefaultView;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ButtonOkMatrixA_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(ref _matrixA, DataGridMatrixA, TextBoxRowsNumMatrixA, TextBoxColumnsNumMatrixA);
        }

        private void ButtonOkMatrixB_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(ref _matrixB, DataGridMatrixB, TextBoxRowsNumMatrixB, TextBoxColumnsNumMatrixB);
        }

        private async void ButtonCalculateMatrices_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RadioButtonAddition.IsChecked)
            {
                await CalculateMatricesAndSetResultAsync(Operations.Addition);
            }
        }

        private async void ButtonCalculateMatrices2_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RadioButtonSubtraction.IsChecked)
            {
                await CalculateMatricesAndSetResultAsync(Operations.Subtraction);
            }
        }

        private async void ButtonCalculateMatrices3_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)RadioButtonMultiplication.IsChecked)
            {
                await CalculateMatricesAndSetResultAsync(Operations.Multiplication);
            }
        }
    }
}
