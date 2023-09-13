namespace LibraryApp.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Isbn
    {
        public long IsbnCode { get; set; }

        public Isbn(long isbnCode)
        {
            IsbnCode = isbnCode;
        }
    }

}
