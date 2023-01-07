using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibraryApi.Dtos.Book
{
    public class UpdateBookDto : RegisterBookDto
    {
        public int BookId { get; set; }
    }
}
