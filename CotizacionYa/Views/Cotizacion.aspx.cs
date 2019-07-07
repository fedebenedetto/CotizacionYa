using Presenter;
using System;
using System.Web.UI.WebControls;
using Utils;
using static Interface.ICotizacion;

namespace CotizacionYa.Views
{
    public partial class Cotizacion : System.Web.UI.Page, ICotizacionView
    {
        ICotizacionPresenter presenter;
        VariablesGlobales variables;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new CotizacionPresenter();
            variables = new VariablesGlobales();
            if (!IsPostBack)
            {
                lstMoneda.SelectedIndex = 0;
            }
            else
            {
                CargarGrilla();
            }
        }


        #region metodos
        /// <summary>
        /// muestra mensajes en pantalla
        /// </summary>
        /// <param name="mensaje"></param>
        public void ShowMsg(string mensaje, string tipo)
        {
            LimpiarMensajes();
            lblMensajes.Text = mensaje;
            hiddError.Value = mensaje;
            hiddTipo.Value = tipo;
        }

        /// <summary>
        /// limpia lblmensajes
        /// </summary>
        private void LimpiarMensajes()
        {
            lblMensajes.Text = string.Empty;
            hiddError.Value = string.Empty;
            hiddTipo.Value = string.Empty;
        }

        /// <summary>
        /// carga la grilla de acuerdo al dropdown
        /// </summary>
        private void CargarGrilla()
        {
            try
            {
                string source = lstMoneda.SelectedValue;
                if (!string.IsNullOrEmpty(source))
                {
                    if (source.Equals("Dolar"))
                    {
                        var list = presenter.GetDolar();
                        if (list != null && list.Count > 0)
                        {
                            dgvCotizacion.DataSource = list;
                            dgvCotizacion.DataBind();
                        }
                    }
                    else if (source.Equals("Euro"))
                    {
                        var list = presenter.GetEuro();
                        if (list != null && list.Count > 0)
                        {
                            dgvCotizacion.DataSource = list;
                            dgvCotizacion.DataBind();
                        }
                    }
                    else if (source.Equals("Real"))
                    {
                        var list = presenter.GetReal();
                        if (list != null && list.Count > 0)
                        {
                            dgvCotizacion.DataSource = list;
                            dgvCotizacion.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                presenter.SetMsg(ex.Message, variables.SwalError());
            }
        }
        #endregion

        #region eventos

        /// <summary>
        /// evento de lstMoneda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lstMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGrilla();
            }
            catch (Exception ex)
            {
                presenter.SetMsg(ex.Message, variables.SwalError());
            }
        }

        /// <summary>
        /// rowdatabound de grilla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void dgvCotizacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (dgvCotizacion.DataSource != null)
                    {
                        string origen = e.Row.Cells[1].Text;
                        string parse = presenter.ParseMoneda(origen);
                        e.Row.Cells[1].Text = parse;
                        string destino = e.Row.Cells[3].Text;
                        parse = presenter.ParseMoneda(destino);
                        e.Row.Cells[3].Text = parse;
                        string fecha = e.Row.Cells[0].Text;
                        DateTime fechaParse = fecha == "&nbsp" ? DateTime.Now : DateTime.Parse(fecha);
                        e.Row.Cells[0].Text = fechaParse.ToShortDateString() + " " + fechaParse.ToShortTimeString();
                        parse = presenter.GetSimbolo(origen);
                        string valor = e.Row.Cells[2].Text;
                        e.Row.Cells[2].Text = parse + " " + valor;
                        valor = e.Row.Cells[4].Text;
                        parse = presenter.GetSimbolo(destino);
                        e.Row.Cells[4].Text = parse + " " + valor;
                    }
                }
            }
            catch (Exception ex)
            {
                presenter.SetMsg(ex.Message, variables.SwalError());
            }
        }

        /// <summary>
        /// load de uodatepanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpdatePanel1_Load(object sender, EventArgs e)
        {
            try
            {
                CargarGrilla();
            }
            catch (Exception ex)
            {
                presenter.SetMsg(ex.Message, variables.SwalError());
            }
        }

        #endregion

    }
}