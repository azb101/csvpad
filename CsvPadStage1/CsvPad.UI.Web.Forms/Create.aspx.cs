using CsvPad.Csv;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CsvPad.UI.Web.Forms
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateCsvGrid();
        }

        private void GenerateCsvGrid()
        {
            csvTableGrid.Controls.Clear();

            int dim = 10;
            int.TryParse(ConfigurationManager.AppSettings["CsvDimension"], out dim);
            
            Table table = new Table();
            table.ID = "dynamicTable";

            for (int i = 0; i < dim; i++)
            {
                var row = new TableRow();

                for (int j = 0; j < dim; j++)
                {
                    var cell = new TableCell();

                    var textbox = new TextBox();
                    textbox.ID = "tbx_" + i + "_"+ j;

                    cell.Controls.Add(textbox);
                    row.Cells.Add(cell);
                }

                table.Rows.Add(row);
            }

            csvTableGrid.Controls.Add(table);
        }

        protected void btnFinishCreate_Click(object sender, EventArgs e)
        {
            if (csvTableGrid.Controls.Count <= 0)
                return;

            try
            {
                bool hasHeader = bool.Parse(csvMakeFirstRowHeader.SelectedValue);
                string title = csvTitle.Text;
                if (string.IsNullOrWhiteSpace(title))
                    return;



                // creating
                var newCsv = new CsvTable();
                newCsv.Location = new Uri( Server.MapPath("~/App_Data/csv") + "/" + title + ".csv");
                newCsv.Settings = new CsvSettings()
                {
                    Header = hasHeader,
                    Separator = csvSeparator.SelectedValue
                };

                Table table = (Table)csvTableGrid.FindControl("dynamicTable");
                if (table == null)
                    return;

                List<CsvRecord> records = new List<CsvRecord>();
                int i = 0;
                foreach (TableRow row in table.Rows)
                {
                    var record = new CsvRecord();
                    record.Id = i;

                    int j = 0;
                    foreach (TableCell cell in row.Cells)
                    {
                        TextBox textBox = (TextBox)cell.Controls[0];

                        record.Fields.Add(new CsvField() { Id = j, Value = textBox.Text });
                        j++;
                    }

                    records.Add(record);
                    i++;
                }

                if (hasHeader)
                {
                    newCsv.Header = records[0];
                    newCsv.Records = records.Skip(1).ToList();
                }
                else
                {
                    newCsv.Records = records;
                }


                var service = CustomServiceLocator.Instance.GetCsvService();


                service.SaveTable(newCsv);

                Response.Redirect("~/", true);
            }
            catch (Exception ex)
            {
                // alert here and log error
            }
        }

        protected void btnLeave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/", true);
        }
    }
}