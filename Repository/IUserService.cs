namespace eBook.Repository
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}