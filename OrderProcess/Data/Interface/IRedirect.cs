using Microsoft.AspNet.Identity.EntityFramework;

namespace OrderProcess.Data.Interface
{
    public interface IRedirect
    {
        string LoginRedirect(IdentityRole role);
    }
}