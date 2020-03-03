using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Authorize]
    public class BookController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            using (var context = new CnBContext())
            {
                return Ok(await context.books.Include(x => x.Reviews).ToListAsync());
            }
        }
    }
}
