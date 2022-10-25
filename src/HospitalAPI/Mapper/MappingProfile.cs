﻿using System.Collections.Generic;
using AutoMapper;
using HospitalAPI.Dtos;
using HospitalAPI.Dtos.Request;
using HospitalAPI.Dtos.Response;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.sharedModel;

namespace HospitalAPI.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
            {
                CreateMap<SpecializationResponse, Specialization>();
                CreateMap<Specialization, SpecializationResponse>();
                CreateMap<Doctor, DoctorResponse>();
                CreateMap<DoctorRequest,Doctor>();
                CreateMap<PatientRequest,Patient>();
                CreateMap<Patient,PatientResponse>();
                CreateMap<RoomResponse,Room>();
                CreateMap<RoomRequest,Room>();
                CreateMap<AddressResponse,Address>();
                CreateMap<Address,AddressResponse>();
                CreateMap<Room,RoomResponse>();
                CreateMap<AppointmentRequest, Appointment>();
                CreateMap<Appointment,AppointmentResponse>();
            }
    }
    
}