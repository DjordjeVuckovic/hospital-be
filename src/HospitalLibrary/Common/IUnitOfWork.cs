﻿using System;
using System.Threading.Tasks;
using HospitalLibrary.ApplicationUsers.Repository;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Feedbacks.Repository;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Rooms.Repository;

namespace HospitalLibrary.Common
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ISpecializationsRepository SpecializationsRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IFeedbackRepository FeedbackRepository { get; }
        IWorkingSchueduleRepository WorkingSchueduleRepository { get; }
        IFloorRepository FloorRepository { get; }
        IBuildingRepository BuildingRepository { get; }
        IGRoomRepository GRoomRepository { get; }
        IRoomRepository RoomRepository { get; }
        IApplicationUserRepository UserRepository { get; }
        T GetRepository<T>() where T : class;
        Task CompleteAsync();
    }
}