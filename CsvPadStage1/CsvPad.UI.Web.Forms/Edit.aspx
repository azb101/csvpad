<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="CsvPad.UI.Web.Forms.Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CsvPad 0.0.0.1</title>


    <link href="./Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="./Styles/Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Create">
            <div class="actions">
                <asp:Button ID="btnLeave" runat="server" Text="Close" 
                            CssClass="btn btn-sm action-btn" 
                            OnClick="btnLeave_Click" />
                <asp:Button ID="btnFinishSave" runat="server" Text="Save" 
                            CssClass="btn btn-sm action-btn" 
                            OnClick="btnFinishSave_Click" />
                
                Title *
                <asp:TextBox ID="csvTitle" runat="server" ReadOnly="true"></asp:TextBox>
                Separator
                <asp:DropDownList ID="csvSeparator" runat="server" CssClass="ddlSeparator">
                    <asp:ListItem Value=";" Text="semicolon" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="," Text="comma" ></asp:ListItem>
                </asp:DropDownList>
                HeaderRow
                 <asp:DropDownList ID="csvMakeFirstRowHeader" runat="server" CssClass="ddlSeparator">
                    <asp:ListItem Value="true" Text="Yes" Selected="true"></asp:ListItem>
                    <asp:ListItem Value="false" Text="No"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="csv-content">
                <asp:PlaceHolder ID="csvTableGrid" runat="server"></asp:PlaceHolder>
            </div>
        </div> 
    </form>
</body>
</html>
