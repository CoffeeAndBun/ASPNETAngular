using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;
using WebApi.Models.Entities;

namespace WebApi.Controllers
{
    public class ReviewController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] ReviewViewModel review)
        {
            using (var context = new CnBContext())
            {
                var book = await context.books.FirstOrDefaultAsync(b => b.Id == review.BookId);
                if (book == null)
                {
                    return NotFound();
                }

                var newReview = context.reviews.Add(new Review
                {
                    BookId = book.Id,
                    Description = review.Description,
                    Rating = review.Rating
                });

                await context.SaveChangesAsync();
                return Ok(new ReviewViewModel(newReview));
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            using (var context = new CnBContext())
            {
                var review = await context.reviews.FirstOrDefaultAsync(r => r.Id == id);
                if (review == null)
                {
                    return NotFound();
                }

                context.reviews.Remove(review);
                await context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
