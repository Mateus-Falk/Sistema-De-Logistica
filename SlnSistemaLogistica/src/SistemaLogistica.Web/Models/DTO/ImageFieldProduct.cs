using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaLogistica.Web.Models.DTO
{
    public class ImageFieldProduct
    {
        public int idProduct { get; set; }

        [DataType(DataType.Upload)]
        [DisplayName("Upload Image")]
        public string imageProduct { get; set; }
    }
}
