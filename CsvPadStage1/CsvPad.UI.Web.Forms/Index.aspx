<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CsvPad.UI.Web.Forms.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CsvPad 0.0.0.1</title>


    <link href="./Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="./Styles/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="content-wrapper clearfix">
            <div class="menu">
                <asp:HyperLink ID="HyperLink1" runat="server" class="to-main-page-link" NavigateUrl="~/Index.aspx">Home</asp:HyperLink>
                <asp:HyperLink ID="HyperLink2" runat="server" class="menu-item btn-create" NavigateUrl="~/Create.aspx">Create</asp:HyperLink>

                <asp:TextBox ID="TextBox1" runat="server" class="form-control search-panel" placeholder="Enter to filter"></asp:TextBox>
                <ul class="csv-files">
                    <%
                        if (CsvFiles != null)
                        {
                            foreach (var uri in CsvFiles)
                            {
                                Response.Write("<li class='csv-file " + (HttpUtility.UrlDecode(Request.QueryString["currentFile"]) == HttpUtility.UrlDecode(uri.AbsolutePath) ?
                                                    "active-csv" : "") + "'> <a href='/Index.aspx?currentFile="
                                                    + uri.AbsolutePath + "' class=''/> " +
                                                    System.IO.Path.GetFileName(HttpUtility.UrlDecode(uri.AbsolutePath)) + "</a> </li>");
                            }
                        }
                    %>
                </ul>
            </div>
            <div class="content">
                <div class="action-panel clearfix">
                    <%
                        if (string.IsNullOrEmpty(Request.QueryString["currentFile"]))
                        {
                            Response.Write("<span class='head'> File: not choosen </span>");
                        }
                        else
                        {
                            Response.Write("<span class='head'> File: " + System.IO.Path.GetFileName(Request.QueryString["currentFile"]) + " </span>");
                        }
                    %>

                    <asp:Button ID="Button1" runat="server" class='btn btn-sm action-btn' Text="Edit" OnClick="btnEdit_Click" />
                    <asp:Button ID="Button2" runat="server" class='btn btn-sm action-btn' Text="Delete" OnClick="btnDelete_Click" />
                </div>
                <div class="preview">
                    <p>
                        Preview of file will be here soon
                    </p>
                    <p>
                        If you want to see the content of file choose file and press "Edit" button
                    </p>
                </div>
            </div>
        </div>
    </form>


</body>
</html>
