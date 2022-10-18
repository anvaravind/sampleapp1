using Microsoft.AspNetCore.Mvc;

namespace SchedulerSampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
       

        private readonly ILogger<BooktController> _logger;
        private readonly BookDB _efbook;

        public BooktController(ILogger<BooktController> logger, BookDB efbook)
        {
            _logger = logger;
            _efbook = efbook;
        }

        [HttpGet]
        [Route("getbooks")]
        public IEnumerable<Book> getbooks()
        {
            return _efbook.Books.ToList();
           
        }


        [HttpPost]
        [Route("addbooks")]
        public Book Addbook(Book _book)
        {
            _logger.LogError($"Triggered at {DateTime.UtcNow}");
            _book.ISBN = Guid.NewGuid().ToString();
            _book.createddate = DateTime.UtcNow;
            _efbook.Add(_book);
            _efbook.SaveChanges();
            return (_book);

        }

        [HttpGet]
        [Route("deletebooks")]
        public bool resetdata()
        {
           foreach(var _ in _efbook.Books)
            {
                _efbook.Remove(_);
            }
            _efbook.SaveChanges();
            if (_efbook.Books.ToList().Count == 0)
                return true;
            return false;

        }





    }
}
