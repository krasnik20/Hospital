using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;

namespace Hospital
{
    public static class ServiceProvider
    {
        public static IServiceProvider Instance { get; }

        static ServiceProvider()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection

                .AddSingleton<ICRUD<Patient>, PatientService>()
                .AddSingleton<ICRUD<Cure>, EntityServiceBase<Cure>>()
                .AddSingleton<ICRUD<Disease>, EntityServiceBase<Disease>>()

                .AddTransient<EditCureViewModel>()
                .AddTransient<EditPatientViewModel>()
                .AddTransient<EditTreatmentViewModel>()
                .AddTransient<CuresViewModel>()
                .AddTransient<EditRoomViewModel>()
                .AddTransient<PatientsViewModel>()
                .AddTransient<RoomsViewModel>();

            Instance = serviceCollection.BuildServiceProvider();
        }


    }
}
