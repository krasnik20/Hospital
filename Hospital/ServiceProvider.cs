using Hospital.Services;
using Hospital.Views.Dialogues;
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

                .AddSingleton<ICRUD<Patient>, PatientsService>()
                .AddSingleton<ICRUD<Cure>, EntityServiceBase<Cure>>()
                .AddSingleton<ICRUD<Disease>, EntityServiceBase<Disease>>()
                .AddSingleton<ICRUD<Room>, RoomsService>()
                .AddSingleton<ICRUD<Doctor>, EntityServiceBase<Doctor>>()

                .AddTransient<IEditDialog<Room>, EditRoomDialogue>()
                .AddTransient<IEditDialog<Cure>, EditCureDialogue>()
                .AddTransient<IEditDialog<Patient>, EditPatientDialogue>()
                .AddTransient<IEditDialog<Disease>, EditDiseaseDialogue>()
                .AddTransient<IEditDialog<Doctor>, EditDoctorDialogue>();

            Instance = serviceCollection.BuildServiceProvider();
        }


    }
}
