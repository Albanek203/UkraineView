namespace DLL.Repository;

public class AddressRepository : BaseRepository<Address> {
    public AddressRepository(UkraineContext context) : base(context) { }
}