namespace ClassLibrary1.Services;

public class TenantProvider : ITenantProvider
{
    int ITenantProvider.GetTenantId()
    {
        return 2;
    }
}
