namespace Gnome.Core.Service
{
    public interface IUserSecurityService
    {
        byte[] CreatePassword(string password, byte[] salt);
        byte[] GetSalt();
        bool Verify(string password, byte[] hashed, byte[] salt);
    }
}