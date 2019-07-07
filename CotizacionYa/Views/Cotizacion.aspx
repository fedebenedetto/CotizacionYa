<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Master.Master" AutoEventWireup="true" CodeBehind="Cotizacion.aspx.cs" Inherits="CotizacionYa.Views.Cotizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <form runat="server">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <div class="panel-heading">

                        <div class="actions pull-left">
                            <legend>Filtro</legend>
                            <table>
                                <tr class="row">
                                    <td style="text-align: left; width: 78px;"></td>

                                    <td style="text-align: left">
                                        <label class="control-label">Elegir Moneda: </label>
                                    </td>
                                    <td style="text-align: right">&nbsp;
                                        <asp:DropDownList ID="lstMoneda" class="dropdown-toggle" runat="server" AutoPostBack="true" onchange="return IndexChanged();" OnSelectedIndexChanged="lstMoneda_SelectedIndexChanged">
                                            <asp:ListItem Value="">--Seleccione una Moneda--</asp:ListItem>
                                            <asp:ListItem Value="Dolar">Dolar</asp:ListItem>
                                            <asp:ListItem Value="Euro">Euro</asp:ListItem>
                                            <asp:ListItem Value="Real">Real</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <div class="form-group">
                                <div class="col-sm-12">
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <legend>Cotización</legend>
                                    <br />
                                    <br />
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" OnLoad="UpdatePanel1_Load">
                                        <ContentTemplate>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="text-align: left; width: 78px;"></td>
                                                    <td style="text-align: left">
                                                        <asp:GridView ID="dgvCotizacion" runat="server" class="table table-striped" AllowPaging="True" AutoGenerateColumns="false"
                                                            BackColor="White" BorderColor="White"
                                                            BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" EnableViewState="false" Width="963px" DataKeyNames="Source, Target"
                                                            OnRowDataBound="dgvCotizacion_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="Updated" HeaderText="Hora de Actualización" />
                                                                <asp:BoundField DataField="Target" HeaderText="Moneda Origen" />
                                                                <asp:BoundField DataField="Quantity" HeaderText="Valor Moneda Origen" />
                                                                <asp:BoundField DataField="Source" HeaderText="Moneda Destino" />
                                                                <asp:BoundField DataField="Value" HeaderText="Valor Moneda Destino" />
                                                            </Columns>
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                            <SortedAscendingHeaderStyle BackColor="#594B9C" />
                                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                            <SortedDescendingHeaderStyle BackColor="#33276A" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="lblMensajes" runat="server" Text="" class="validation-summary-errors text-danger"></asp:Label>
                                    <asp:HiddenField ID="hiddMensajes" runat="server" />
                                    <asp:HiddenField ID="hiddTipo" runat="server" />
                                    <asp:HiddenField ID="hiddError" runat="server" Value="" />
                                    <asp:HiddenField ID="hiddControl" runat="server" Value="" />
                                </td>
                            </tr>
                        </table>
                        <!-- Modal -->
                        <div class="modal fade" id="loadMe" tabindex="-1" role="dialog" aria-labelledby="loadMeLabel">
                            <div class="modal-dialog modal-sm" role="document">
                                <div class="modal-content">
                                    <div class="modal-body text-center">
                                        <div class="loader"></div>
                                        <div class="spinner"></div>
                                        <div class="loader-txt">
                                            <p>Buscando Cotizacion...</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
    <script>
        $(function () {
            resetTimer();
            window.onkeypress = resetTimer;

            var text = document.getElementById('<%= hiddError.ClientID %>').value;
            var textControl = document.getElementById('<%= hiddControl.ClientID %>').value;
            var textoTipo = document.getElementById('<%= hiddTipo.ClientID %>').value;
            if (text != '') {
                if (text != textControl) {
                    event.preventDefault();
                    sweetAlertInitialize();
                    swal({
                        title: "Cotización",
                        text: text,
                        type: textoTipo
                    });
                    document.getElementById('<%= hiddError.ClientID %>').value = '';
                }
            }
            var t;

            function resetTimer() {
            clearTimeout(t);

            t = setInterval(Load, 5000);
        }
        });

        //muestra modal loading y refresca el updatepanel
        function Load() {
            $('#loadMe').modal({
                backdrop: "static",
                keyboard: false,
                show: true
            });
            setTimeout(function () {
                $("#loadMe").modal("hide");
                __doPostBack('<%= UpdatePanel1.UniqueID %>');
            }, 1000);
        }

        //funcion que interactua con el drop muestra modal login y llama a su evento
        function IndexChanged() {
              $('#loadMe').modal({
                backdrop: "static",
                keyboard: false,
                show: true
            });
            setTimeout(function () {
                $("#loadMe").modal("hide");
                __doPostBack('<%= lstMoneda.UniqueID %>');
                resetTimer;
            }, 3000);
        }
    </script>
</asp:Content>
