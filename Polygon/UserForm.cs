using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Polygon {
    public partial class UserForm : Form {
        // can be moved to .resx along with designer translatable resources during localization
        const string NUMBER_FORMAT_ERROR_TEXT = "Только числа в десятичном формате!";
        const string EMPTY_CELL_ERROR_TEXT = "Нет пустым значениям!";
        const string ERROR_IN_STRING_TEXT_FORMAT = "Ошибка в строке {0}";
        const string DUPLICATE_VERTICES_TEXT_FORMAT = "Дублирующиеся вершины - {0} шт.";
        const string CALCULATING_TEXT = "Вычисляем..";
        const string CROSSING_FOUND_TEXT = "Присутствует самопересечение";
        const string CLOCKWISE_TEXT_FORMAT = "Площадь: {0:G} Обход по часовой стрелке";
        const string COUNTERCLOCKWISE_TEXT_FORMAT = "Площадь: {0:G} Обход против часовой стрелки";
        
        public UserForm() {
            InitializeComponent();
        }

        void verticesDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e) {
            // validate numeric input
            decimal value;
            verticesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = 
                decimal.TryParse(Convert.ToString(e.FormattedValue), out value) ? String.Empty : NUMBER_FORMAT_ERROR_TEXT;
        }

        void verticesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {
            verticesDataGridView.CellValidating -= verticesDataGridView_CellValidating;
        }

        void verticesDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) {
            verticesDataGridView.CellValidating += verticesDataGridView_CellValidating;
        }

        void verticesDataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e) {
            // validate empty cells in a row
            var row = verticesDataGridView.Rows[e.RowIndex]; 
            if (!row.IsNewRow) {
                foreach (DataGridViewCell cell in row.Cells) {
                    if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString())) {
                        row.ErrorText = EMPTY_CELL_ERROR_TEXT;
                        return;
                    }
                }
            }
            row.ErrorText = String.Empty;
        }

        void calculateAreaButton_Click(object sender, EventArgs e) {
            calculateAreaButton.Enabled = false;
            verticesDataGridView.Enabled = false;
            try {
                var pointList = new List<Point>(verticesDataGridView.Rows.Count);
                foreach (DataGridViewRow row in verticesDataGridView.Rows) {
                    decimal x, y;
                    if (!row.IsNewRow) {
                        if (decimal.TryParse(Convert.ToString(row.Cells[0].Value), out x) && decimal.TryParse(Convert.ToString(row.Cells[1].Value), out y)) {
                            pointList.Add(new Point((double)x, (double)y));
                        } else {
                            outputLabel.Text = string.Format(ERROR_IN_STRING_TEXT_FORMAT, row.Index + 1);
                            return;
                        }
                    }
                }
                outputLabel.Text = CALCULATING_TEXT;
                var polygon = new Polygon(pointList);
                int duplicates = polygon.DuplicateVerticesCount;
                if (duplicates != 0) {
                    outputLabel.Text = string.Format(DUPLICATE_VERTICES_TEXT_FORMAT, duplicates);
                    return;
                }
                if (polygon.HasCrossings()) {
                    outputLabel.Text = CROSSING_FOUND_TEXT;
                    return;
                }
                double result = polygon.CalculateArea();
                outputLabel.Text = result < 0 ? string.Format(CLOCKWISE_TEXT_FORMAT, -result) : string.Format(COUNTERCLOCKWISE_TEXT_FORMAT, result);
            }
            finally {
                calculateAreaButton.Enabled = true;
                verticesDataGridView.Enabled = true;
            }
        }

        void verticesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e) {
            setRowNumbers();
        }

        void verticesDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e) {
            setRowNumbers();
        }

        void setRowNumbers() {
            foreach (DataGridViewRow row in verticesDataGridView.Rows) {
                if (!row.IsNewRow) {
                    row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
                }
            }
        }
    }
}
