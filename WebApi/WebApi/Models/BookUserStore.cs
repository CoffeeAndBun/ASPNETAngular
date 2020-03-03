using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApi.Models
{
    public class BookUserStore : UserStore<IdentityUser>
    {
        public BookUserStore() : base(new CnBContext())
        {
        }
    }
}