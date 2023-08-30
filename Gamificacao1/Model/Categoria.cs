

namespace MRV.Modas
{
    public class CategoriaModel
    {
        public long? CategoriaID { get; set; }
        public Guid CategoriaIDGUID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public static List<CategoriaModel> categorias = new List<CategoriaModel>();
    }
}
