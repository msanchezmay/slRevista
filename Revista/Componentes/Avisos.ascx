<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Avisos.ascx.cs" Inherits="Revista.Componentes.Avisos" %>
<asp:Panel ID="pnlMensaje" runat="server" Style="display: none">
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-sm-4">
            <asp:TextBox ID="TxtAviso" TextMode="MultiLine" runat="server" Style="vertical-align: middle; text-align: left" Height="80px"
                Width="94%" Font-Names="Arial" Font-Size="9pt" Font-Bold="True" CssClass="full-width"></asp:TextBox>

            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-secondary" />
        </div>
        <div class="col-sm-4"></div>
    </div>

    <asp:Label ID="Label1" runat="server" CssClass="text14negro_bold" Text="Revista"></asp:Label>
</asp:Panel>