namespace TareaAPiXD.Models
{
    public class DetalleHojadevida
    {
        public int Id { get; set; }
        public int EntrevistadoId { get; set; }

        public int HojadevidaId { get; set; }

        #region propiedades de navegacion 
        public Entrevistado Entrevistado { get; set; }
        public Hojadevida Hojadevida { get; set; }
        #endregion

    }
}
