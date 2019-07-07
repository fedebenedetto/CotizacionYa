using System.Collections.Generic;
using Model;
using Object;
using Utils;
using static Interface.ICotizacion;

namespace Presenter
{
    public class CotizacionPresenter : ICotizacionPresenter
    {
        ICotizacionView view;
        ICotizacionModel model;
        VariablesGlobales variables;

        public CotizacionPresenter()
        {
            model = new CotizacionModel(this);
            variables = new VariablesGlobales();
        }

        /// <summary>
        /// invoca a model para obtener cotizacion de dolar
        /// </summary>
        /// <returns></returns>
        public List<Objeto.Dolar> GetDolar()
        {
            try
            {
                var list = model.GetDolar();
                return list;
            }
            catch (System.Exception ex)
            {

                SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// invoca a model para obtener cotizacion de Euro
        /// </summary>
        /// <returns></returns>
        public List<Objeto.Euro> GetEuro()
        {
            try
            {
                var list = model.GetEuro();
                return list;
            }
            catch (System.Exception ex)
            {

                SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// invoca a model para obtener cotizacion de real
        /// </summary>
        /// <returns></returns>
        public List<Objeto.Real> GetReal()
        {
            try
            {
                var list = model.GetReal();
                return list;
            }
            catch (System.Exception ex)
            {

                SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// recibe el string de la moneda y devuelve el simbolo de ella
        /// </summary>
        /// <param name="moneda"></param>
        /// <returns></returns>
        public string GetSimbolo(string moneda)
        {
            try
            {
                string parse = string.Empty;
                if (moneda.Equals("ARS"))
                {
                    parse = "$";
                }
                else if (moneda.Equals("USD"))
                {
                    parse = "U$S";
                }
                else if (moneda.Equals("EUR"))
                {
                    parse = "€";
                }
                else if (moneda.Equals("BRL"))
                {
                    parse = "R$";
                }
                return parse;
            }
            catch (System.Exception ex)
            {

                SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// recibe string de moneda y devuleve la descripcion de la moneda
        /// </summary>
        /// <param name="moneda"></param>
        /// <returns></returns>
        public string ParseMoneda(string moneda)
        {
            try
            {
                string parse = string.Empty;
                if (moneda.Equals("ARS"))
                {
                    parse = "Pesos Argentinos";
                }
                else if (moneda.Equals("USD"))
                {
                    parse = "Dolar";
                }
                else if (moneda.Equals("EUR"))
                {
                    parse = "Euro";
                }
                else if (moneda.Equals("BRL"))
                {
                    parse = "Real Brasilero";
                }
                return parse;
            }
            catch (System.Exception ex)
            {

                SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// setea mensajes en view
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="tipo"></param>
        public void SetMsg(string mensaje, string tipo)
        {
            if (view != null)
            {
                view.ShowMsg(mensaje, tipo);
            }
        }

        /// <summary>
        /// setea view
        /// </summary>
        /// <param name="view"></param>
        public void setView(ICotizacionView view)
        {
            this.view = view;
        }
    }
}
