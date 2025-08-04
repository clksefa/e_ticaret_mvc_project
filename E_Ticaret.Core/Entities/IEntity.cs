namespace E_Ticaret.Core.Entities
{
    public interface IEntity // internal kısmını public olarak değiştirdik.
    {
        // Interface'ler Class'larımızda olmak zorunda olan alanları belirtir.
        public int Id { get; set; }
    }
}
