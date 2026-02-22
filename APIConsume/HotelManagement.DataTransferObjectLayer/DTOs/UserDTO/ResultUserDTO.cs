using HotelManagement.DataTransferObjectLayer.DTOs.WorkLocationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataTransferObjectLayer.DTOs.UserDTO
{
    public class ResultUserDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int id { get; set; }
        public string userName { get; set; }
        public string normalizedUserName { get; set; }
        public string email { get; set; }
        public string normalizedEmail { get; set; }
        public bool emailConfirmed { get; set; }
        public object phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public bool twoFactorEnabled { get; set; }

        public ResultWorkLocationDTO WorkLocation { get; set; }
    }
}
