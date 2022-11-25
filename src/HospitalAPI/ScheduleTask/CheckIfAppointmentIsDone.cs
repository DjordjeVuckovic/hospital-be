using System;
using System.Globalization;
using System.Threading.Tasks;
using HospitalLibrary.EquipmentMovement;
using HospitalLibrary.EquipmentMovement.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalAPI.ScheduleTask
{
    public class CheckIfAppointmentIsDone: ScheduledProcessorHospital
    {
        public CheckIfAppointmentIsDone(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
            
        }

        protected override string Schedule => "*/1 * * * *"; // every 1 min 

        public override async Task ProcessInScope(IServiceProvider scopeServiceProvider)
        {
            Console.WriteLine("-------------------------");
            IEquipmentMovementAppointmentService reportSenderService = scopeServiceProvider.GetRequiredService<IEquipmentMovementAppointmentService>();
            
            Console.WriteLine("PikulaTask1 : " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            await reportSenderService.CheckAllAppointmentTimes();

            await Task.Run(() => Task.CompletedTask);
        }
    }
}