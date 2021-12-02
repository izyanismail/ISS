<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homepage.aspx.cs" Inherits="Homepage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
 <head>
    <title>Ajax Api call by jQuery</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {
            $.ajax({
                url: "https://api.wheretheiss.at/v1/satellites",
                type: "GET",
                data: JSON.stringify({$('[id*=Search]').val() }),
                success: function (result) {
                    console.log(result);
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    </script>
    
  </head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:TextBox ID="Search" runat="server" class="autosuggest" ForeColor="Black"  Font-Names="Verdana" 
         Font-Size="Medium" Font-Bold="True" Width="315px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="SearchText()" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
