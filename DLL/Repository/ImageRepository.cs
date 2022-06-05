namespace DLL.Repository;

public class ImageRepository : BaseRepository<Image> {
    public ImageRepository(UkraineContext context) : base(context) { }
}