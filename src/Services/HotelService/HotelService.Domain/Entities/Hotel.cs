using ServiceCore.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelService.Domain.Entities

{
    public class Hotel:IEntity
    {
        [Key] 
        public Guid Id { get; set; }
        public string HotelName { get; set; }
        public string AuthorizedFirstName { get; set; }
        public string AuthorizedLastName { get; set; }
   
        public List<ContactInfo> ContactInfos { get; set; }
    }
}
