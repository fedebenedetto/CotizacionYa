using System.Collections.Generic;
using static Object.Objeto;

namespace Interface
{
    public class ICotizacion
    {
        public interface ICotizacionView
        {
            void ShowMsg(string mensaje, string tipo);
        }

        public interface ICotizacionPresenter
        {
            void setView(ICotizacionView view);
            void SetMsg(string mensaje, string tipo);
            List<Dolar> GetDolar();
            List<Euro> GetEuro();
            List<Real> GetReal();
            string ParseMoneda(string moneda);
            string GetSimbolo(string moneda); 
        }

        public interface ICotizacionModel
        {
            List<Dolar> GetDolar();
            List<Euro> GetEuro();
            List<Real> GetReal(); 
        }
    }
}
