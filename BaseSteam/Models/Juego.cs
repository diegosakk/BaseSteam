namespace BaseSteam.Models;

public partial class Juego
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Categoria { get; set; }

    public int Desarrollador { get; set; }

    public int Editor { get; set; }

    public string? Plataforma { get; set; }

    public int Precio { get; set; }

    public int UsuarioRegistrado { get; set; }
    public virtual Usuario UsuarioRegistradoNavigation { get; set; } = null!;
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;
    public virtual Desarrollador IdDesarrolladorNavigation { get; set; } = null!;
    public virtual Editor IdEditorNavigation { get; set; } = null!;
}
