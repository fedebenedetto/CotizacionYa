using Object;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Utils;
using static Interface.ICotizacion;
using static Object.Objeto;

namespace Model
{
    public class CotizacionModel : ICotizacionModel
    {
        ICotizacionPresenter presenter;
        VariablesGlobales variables;

        public CotizacionModel(ICotizacionPresenter presenter)
        {
            this.presenter = presenter;
            variables = new VariablesGlobales();
        }
        
        /// <summary>
        /// busca la cotizacion del Dolar
        /// </summary>
        /// <returns></returns>
        public List<Dolar> GetDolar()
        {
            try
            {
                List<Dolar> dolars = new List<Dolar>();
                string source = "USD";
                string path = Funciones.Funciones.GetUrl(source);

                var client = new RestClient(path);
                var response = Funciones.Funciones.RestResponse(client, source);
                if (response.IsSuccessful)
                {
                    var result = Moneda.FromJson(response.Content);
                    Dolar dolar = new Dolar {
                        Amount = result.Result.Amount,
                        Quantity = result.Result.Quantity,
                        Source = result.Result.Source,
                        Target = result.Result.Target,
                        Updated = result.Result.Updated,
                        Value = result.Result.Value,
                    };

                    dolars.Add(dolar);
                }
                return dolars;
            }
            catch (Exception ex)
            {

                presenter.SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }

        /// <summary>
        /// busca la cotizacion del Euro
        /// </summary>
        /// <returns></returns>
        public List<Euro> GetEuro()
        {
            try
            {
                List<Euro> euros = new List<Euro>();
                string source = "EUR";
                string path = Funciones.Funciones.GetUrl(source);

                var client = new RestClient(path);
                var response = Funciones.Funciones.RestResponse(client, source);
                if (response.IsSuccessful)
                {
                    var result = Moneda.FromJson(response.Content);
                    Euro euro = new Euro
                    {
                        Amount = result.Result.Amount,
                        Quantity = result.Result.Quantity,
                        Source = result.Result.Source,
                        Target = result.Result.Target,
                        Updated = result.Result.Updated,
                        Value = result.Result.Value,
                    };

                    euros.Add(euro);
                }
                return euros;
            }
            catch (Exception ex)
            {

                presenter.SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }


        /// <summary>
        /// busca la cotizacion del Real
        /// </summary>
        /// <returns></returns>
        public List<Real> GetReal()
        {
            try
            {
                List<Real> reals = new List<Real>();
                string source = "BRL";
                string path = Funciones.Funciones.GetUrl(source);

                var client = new RestClient(path);
                var response = Funciones.Funciones.RestResponse(client, source);
                if (response.IsSuccessful)
                {
                    var result = Moneda.FromJson(response.Content);
                    Real real = new Real
                    {
                        Amount = result.Result.Amount,
                        Quantity = result.Result.Quantity,
                        Source = result.Result.Source,
                        Target = result.Result.Target,
                        Updated = result.Result.Updated,
                        Value = result.Result.Value,
                    };

                    reals.Add(real);
                }
                return reals;
            }
            catch (Exception ex)
            {

                presenter.SetMsg(ex.Message, variables.SwalError());
                return null;
            }
        }
    }
}
