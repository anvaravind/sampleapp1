using System.ComponentModel.DataAnnotations;

namespace SchedulerSampleApp
{
    public class Book
    {

        [Key]
        public String ISBN { get; set; }

        public DateTime createddate { get; set; }
        
    }
}