namespace Gnome.Core.Service.Interfaces
{
    public interface IUserSecurityService
    {
        byte[] CreatePassword(string password, byte[] salt);
        byte[] GetSalt();
        bool Verify(string password, byte[] hashed, byte[] salt);
    }
}