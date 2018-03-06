using System.ComponentModel.DataAnnotations;

namespace web_api_demo.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// Product Category
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Product Price
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}