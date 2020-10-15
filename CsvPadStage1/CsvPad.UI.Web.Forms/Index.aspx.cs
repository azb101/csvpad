using CsvPad.UI.Web.Forms.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace CsvPad.UI.Web.Forms
{
    public partial class Index : System.Web.UI.Page
    {
        private List<Uri> csvFiles;
        public List<Uri> CsvFiles { get { return csvFiles; } }




        protected void Page_Load(object sender, EventArgs e)
        {
            var service = CustomServiceLocator.Instance.GetCsvService();
            csvFiles = service.GetTableLocations();
        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var currentFile = Request.QueryString["currentFile"];
            if (string.IsNullOrWhiteSpace(currentFile))
                return;



            var uri = new Uri(currentFile);

            try
            {
                var service = CustomServiceLocator.Instance.GetCsvService();

                service.DeleteTable(uri);

                Response.Redirect("~/", true);
            }
            catch (MessageException mex)
            {
                // TODO alert
                // custom message for alerting mex.Message
            }
            catch (Exception ex)
            {
                // TODO 
                // log and alert common exception
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var currentFile = Request.QueryString["currentFile"];
            if (string.IsNullOrWhiteSpace(currentFile))
                return;

            Response.Redirect("~/Edit?currentFile=" + currentFile, true);
        }
    }
}