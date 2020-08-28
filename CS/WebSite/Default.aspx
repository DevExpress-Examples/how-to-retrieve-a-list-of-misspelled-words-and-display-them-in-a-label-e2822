<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v13.1, Version=13.1.14.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to retrieve a list of misspelled words and display them in a label</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxMemo ID="memo" runat="server" Height="70px" Width="563px" Text="Accordnig to an englnsih unviersitry sutdy the oredr of letetrs in a word dosen't mttaer, the olny thnig thta's imporantt is that the frsit and last ltteer of eevry word is in the crrecot psoition. The rset can be jmbueld and one is stlil able to read the txet withuot dificultfiy.">
            </dx:ASPxMemo>
            <dx:ASPxLabel ID="lbl" runat="server" Text="Incorrect word - list of suggestions"
                EncodeHtml="false">
            </dx:ASPxLabel>
            <dx:ASPxButton ID="btn" runat="server" Text="Check Spelling" OnClick="btn_Click">
            </dx:ASPxButton>
        </div>
    </form>
</body>
</html>
