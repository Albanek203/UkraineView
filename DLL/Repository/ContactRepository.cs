namespace DLL.Repository;

public class ContactRepository : BaseRepository<Contact> {
    public ContactRepository(UkraineContext context) : base(context) { }
}