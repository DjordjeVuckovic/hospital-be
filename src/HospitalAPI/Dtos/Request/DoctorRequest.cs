﻿using System;

namespace HospitalAPI.Dtos.Request
{
    public class DoctorRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AddressResponse Address { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Jmbg{ get; set; }
        public string Phone{ get; set; }
        public Guid SpecializationId{ get; set; }
       // public IEnumerable<AppointmentDto> Appointments { get; set; }
        public Guid RoomId { get; set; }
    }
}