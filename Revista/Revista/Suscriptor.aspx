<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Suscriptor.aspx.cs" Inherits="Revista.Revista.Suscriptor" %>

<%@ Register Src="~/Componentes/Avisos.ascx" TagPrefix="uc1" TagName="Avisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function solonumeros(e) {
 
            var key;
 
            if (window.event) // IE
            {
                key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                key = e.which;
            }
 
            if (key < 48 || key > 57) {
                return false;
            }
 
            return true;
        }
 
    </script>
    <div class="card-body">
        <div class="card-header text-left font-weight-bold text-uppercase py-2">
            <h1><span class="align-middle">Suscriptor</span></h1>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <h3><span class="align-middle">Buscar Suscriptor</span></h3>
            </div>
            <div class="col-sm-4">
                <label>Tipo Documento</label><br />
                <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="full-width">
                    <asp:ListItem Selected="True">DNI</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <label>Numero de Documento</label><br />
            
                <asp:TextBox runat="server" ID="txtNumeroDocumento" CssClass="full-width" TextMode="Number" ></asp:TextBox>
            </div>

            <div class="col-sm-4">
                <asp:Button ID="btnBuscar" runat="server" Text="&nbsp;Buscar&nbsp;" class="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <h3><span class="align-middle">Datos del Suscriptor</span></h3>
            </div>
            <div class="col-sm-4">
                <label>Nombre</label><br />
                <asp:TextBox ID="txtNombre" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <label>Apellido</label><br />
                <asp:TextBox ID="txtApellido" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <br />
                <asp:Button ID="btnNuevo" runat="server" Text="&nbsp;&nbsp;Nuevo&nbsp;&nbsp;" class="btn btn-primary" OnClick="btnNuevo_Click" />
            </div>

            <div class="col-sm-4">
                <label>Dirección</label><br />
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <label>Email</label><br />
                <asp:TextBox ID="txtMail" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <br />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-info" OnClick="btnModificar_Click" />
            </div>

            <div class="col-sm-4">
                <label>Telefono</label>
                <br />
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <label>Estado</label><br />
                <asp:TextBox ID="txtEstado" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <br />
                <asp:Button ID="btnGuardar" runat="server" Text="&nbsp;Guardar" class="btn btn-success" OnClick="btnGuardar_Click" />
            </div>

            <div class="col-sm-4">
                <label>Nombre de Usuario</label><br />
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="full-width"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <label>Contraseña</label><br />
                 
                    <asp:TextBox ID="txtContrasenia" runat="server" CssClass="full-width" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-sm-4">
                <br />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" class="btn btn-warning" OnClick="btnCancelar_Click" />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <br />
                <br />
                <asp:HiddenField ID="txtIdSuscriptor" runat="server" Value="0" />
                <asp:HiddenField ID="txtContraseniaUpdate" runat="server" Value="0" />
                <asp:HiddenField ID="txtDias" runat="server" Value="-1" />
                <asp:Button ID="btnRegistarSubscripcion" runat="server" Text="Registrar Suscripcion" class="btn btn-success" OnClick="btnRegistarSubscripcion_Click" />
                <br />
                <br />
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDatos_RowCommand" OnRowDataBound="gvDatos_RowDataBound">
                    <Columns>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="ChRegistro" runat="server" ToolTip='<%# Bind("Idsuscriptor") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Button"
                            ShowSelectButton="True" SelectText="Editar" />
                        
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Tipodocumento" HeaderText="Tipodocumento" />
                        <asp:BoundField DataField="Numerodocumento" HeaderText="Numerodocumento" />
                        <asp:BoundField DataField="Nombreusuario" HeaderText="Nombreusuario" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Idsuscriptor" HeaderText="Idsuscriptor" />
                    </Columns>
                   
                </asp:GridView>
            </div>
        </div>
    </div>
    <uc1:Avisos runat="server" ID="Avisos" />
</asp:Content>