namespace JWTPractice
{
    public interface IJWTAuthenticationManager
    {
        //Middleware'da authentication işlemlerini yönetecek olan class'ın implement edeceği inteerface
        string Authenticate(string userName, string password);
    }
}
