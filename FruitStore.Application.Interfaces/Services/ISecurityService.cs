namespace FruitStore.Application.Interfaces.Services
{
    public interface ISecurityService
    {
        string Encrypt(string value, string salt);
    }
}
