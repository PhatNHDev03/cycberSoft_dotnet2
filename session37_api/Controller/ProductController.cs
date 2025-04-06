using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using session37_api.Data;
using session37_api.Models;
namespace session37_api.Controller
{
    [ApiController] // thong bao cho .net biet cai controller minh tu tao
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAlls")]
        //fromQuery la http....?searh&page&pageSize
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(
            [FromQuery] string? search = null,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10
        )
        {
            // lấy header ben fe trueyn tooken de minh lay ra
            var userHeader = Request.Headers["User-Agent"].ToString();
            // can dung ham nao de toi uu chi phi query
            Console.WriteLine($"user-agent: {userHeader}");
            //asQueryAble
            // cach 1 : asqueryAble ==> nhieu recommend
            // loc data
            //phan trang
            // tim kiem
            //toi uu hieu suat
            // giam tai database
            // Explain 
            //=>> tận dụng cơ chế cache built-in
            //lazy loading:  --> load khi can thiet thoi
            // ko quert truc tiep luon --> den khi nao ToLítÁync để đợi mình phân trang, taho tác trên nó đã thi no moi tra data
            var query = _context.Products.AsQueryable();
            // cach 2 firstOrdefault
            // kém hiệu quả vì hàm nầy connect tới db lấy all xong mới filter db
            // cach 3 where.firstOrdefault
            // select * From Product where id= id  kém heiẹu quả nhất
            //ap dung  cac dieu kien tim kiem
            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            //phan trang
            var total = await query.CountAsync();
            var TotalPages = (int)Math.Ceiling(total / (decimal)pageSize);
            var products = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(new
            {
                Data = products,
                Pagination = new
                {
                    totalItem = total,
                    TotalPage = TotalPages,
                    CurrentPage = page,
                    PageSize = pageSize
                }
            });
        }

        //define API Post
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            //kiem tra input
            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new
                    {
                        Message = "InVlaid input",
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    }
                );
            }
            var item = await _context.Products.FirstOrDefaultAsync(x => x.Name == product.Name);
            if (item != null)
            {
                return BadRequest(
                    new
                    {
                        message = "Product name already exist"
                    }
                );
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);

            //kiem tra san pham da ton tai ?
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            //cach 1 dung findAsync ==> recommend
            // tim theo primaryKey (defualt index) ==> nen recommend
            // co chế cache built-in
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest(
                    new
                    {
                        message = "invalid id"
                    }
                );
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(
                    new
                    {
                        message = "invlaid update",
                        Errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                    }
                );
            }
            var item = await _context.Products.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            //update product
            //chuyen entity Product ve model update nhung ma saveChangesAsync
            //_context.Entry(product).State = EntityState.Modified;
            item.Name = product.Name;
            item.Price = product.Price;
            item.Description = product.Description;
            _context.Products.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> deleteById(int id)
        {
            if (id == null) return BadRequest();
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound(
                new
                {
                    message = "Product not found"
                }
            );
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(
               new { message = "product deleted successfully" }
            );
        }
    }

}