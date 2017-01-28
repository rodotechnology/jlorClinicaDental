using System.Collections;
using capaDatos;

/// <summary>
/// Descripción breve de ordenPago
/// </summary>
namespace capaNegocios
{
    public class ordenPago
    {
        public ordenPago()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public ArrayList getAllPendientesPago()
        {
            datosPago objPagos = new datosPago();
            return objPagos.getPendientesPago();
        }
    }
}