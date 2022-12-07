namespace Maya.Models.ViewModels
{
    public class DetalleVM
    {
        //constructor para inicializar la variable producto y no tenerla que inicializar en el controlador
        public DetalleVM()
        {
            Producto = new Producto();  
        }
        public Producto Producto { get; set; }
        public bool ExisteEnCarro { get; set; }
    }
}
