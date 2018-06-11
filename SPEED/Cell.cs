using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace SPEED
{
    internal static class Cell
    {
        public static string GetCellValue(DataGrid dataGrid, int row, int column)
        {
            DataGridRow rowContainer = GetRow(dataGrid, row);
            if (rowContainer != null)
            {
                DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);

                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }

                try
                {
                    TextBlock text = (TextBlock)cell.Content;
                    return text.Text;
                }
                catch
                {
                    CheckBox text = (CheckBox)cell.Content;
                    if (text.IsChecked == true)
                        return "1";
                    else
                        return "0";
                }
            }

            return null;
        }

        private static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        private static DataGridRow GetRow(DataGrid grid, int rowIndex)
        {
            return (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(rowIndex);
        }
    }
}
