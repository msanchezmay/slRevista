<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Suscripcion.aspx.cs" Inherits="Revista.Revista.Suscripcion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card-body">
        <div class="card-header text-left font-weight-bold text-uppercase py-2">
            <h1><span class="align-middle">Suscripción</span></h1>
        </div>
        <div class="row">
            <div class="col-sm-4">
                <label>Fecha Alta</label><br />
                <asp:TextBox ID="txtFechaAlt" runat="server"  type="Date"></asp:TextBox>
                
            </div>
            <div class="col-sm-4">
                <label>Fecha Fin</label><br />
             
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date"></asp:TextBox>
                
            </div>
            <div class="col-sm-4">
                <label>Motivo</label><br />
            
                <asp:TextBox runat="server" ID="txtMotivo" CssClass="full-width" ></asp:TextBox>
            </div>
            <div class="col-sm-12">
                <br />
                <br />
                 <asp:Button ID="btnGuardar" runat="server" Text="&nbsp;Guardar&nbsp;" class="btn btn-success" OnClick="btnGuardar_Click" />
                <br />
                <br />
            </div>
        </div>
    </div>
</asp:Content>
