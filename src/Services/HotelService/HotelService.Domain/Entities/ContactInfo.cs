using HotelService.Domain.Enums;
using ServiceCore.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using static HotelService.Domain.Enums.ContactInfoType;

namespace HotelService.Domain.Entities
{
    public class ContactInfo:IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid HotelId { get; set; } 
        public ContactType Type { get; set; } 
        public string Content { get; set; } 

    }
}
