using Model.Model;
using System;
using System.Linq;

namespace Hospital.Services
{
    class RoomsService : EntityServiceBase<Room>
    {
        public RoomsService()
        {
            Action<Room> CheckNumber = (Room item) =>
            {
                if(item.Number <= 0 || dbctx.Set<Room>().Any(r => r.Id != item.Id && r.Number == item.Number))
                    throw new Exception();
            };

            BeforeUpdate += CheckNumber;
            BeforeCreate += CheckNumber;

            AfterRead += (Room[] items) =>
            {
                foreach (var item in items)
                {
                    dbctx.Entry(item).Reference(i => i.Doctor).Load();
                }
            };
        }
    }
}
