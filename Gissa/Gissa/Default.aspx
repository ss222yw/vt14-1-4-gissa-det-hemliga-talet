<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gissa.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link href="~/Content/Red.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="Head1">
        <h1>Gissa det hemliga talet</h1>
    </div>
    <!-- whiteSpace -->
    <div class="clear"></div>
    <form id="form1" runat="server">
        <!-- Summary validation -->
        <asp:ValidationSummary ID="ValidationSummary" runat="server" HeaderText="En fel inträffade. Korrigera felet och gör ett nytt försök." CssClass="Summary" />
        <span id="guess">Ange ett tal mellan 1 och 100 :</span>
        <!-- TextBox -->
        <div>
            <asp:TextBox ID="SecretBox" runat="server" Enabled="true"></asp:TextBox>
            <!-- Validation -->
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" CssClass="RequiredFieldValidator" Text="*" runat="server" ErrorMessage="Ett tal mellan 1 och 100 måste anges!!!" ControlToValidate="SecretBox" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" CssClass="RangeValidator1" runat="server" ErrorMessage="Talet måste ligga mellan 1 och 100" MaximumValue="100" MinimumValue="1" Display="Dynamic" ControlToValidate="SecretBox" Type="Integer" Text="*"></asp:RangeValidator>
        </div>
        <!-- SendButton -->
        <div class="SendButton">
            <asp:Button ID="SendButton" runat="server" Text="Skicka gissning" Enabled="true" OnClick="SendButton_Click" />
        </div>
        <!-- New SendButton -->
        <div class="NewSendButton">
            <asp:Button ID="NewSendButton" runat="server" Text="Slumpa nytt hemligt tal" Visible="false" OnClick="NewSendButton_Click" />
        </div>
        <!--Place Holder -->
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <p>
                <asp:Label ID="guesses" runat="server" Text=""></asp:Label></p>
        </asp:PlaceHolder>


        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
            <p>
                <asp:Label ID="ResultLabel" runat="server" Text=""></asp:Label></p>
        </asp:PlaceHolder>

    </form>
    <script type="text/javascript">
        var textBox = document.getElementById("SecretBox");
        SecretBox.focus();
        SecretBox.select();
    </script>
</body>
</html>
