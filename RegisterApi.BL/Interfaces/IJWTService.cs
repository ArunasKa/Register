namespace RegisterApi.BL.Interfaces
{
    public interface IJWTService
    {
        string GetJwtToken(string userName, string role);

    }
}
