using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Operations
{
    public class ConvertShift
    {
        public Shift Convert(ShiftModel shift)
        {
            var newShift = new Shift()
            {
                ShiftID = shift.ShiftID,

                InitialHour = shift.InitialHour,

                EndingHour = shift.EndingHour
            };

            return newShift;
        }

        public ShiftModel ConvertModel(Shift shift)
        {
            var newShift = new ShiftModel()
            {
                ShiftID = shift.ShiftID,

                InitialHour = shift.InitialHour,

                EndingHour = shift.EndingHour
            };

            return newShift;
        }

    }
}
