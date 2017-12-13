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

            var newShift = new Shift();

            if (shift != null)
            {

                newShift.ID = shift.ID;

                newShift.InitialHour = shift.InitialHour;

                newShift.EndingHour = shift.EndingHour;
                
            }


            return newShift;
        }

        public ShiftModel ConvertModel(Shift shift)
        {
            var newShift = new ShiftModel()
            {
                ID = shift.ID,

                InitialHour = shift.InitialHour,

                EndingHour = shift.EndingHour
            };

            return newShift;
        }

    }
}
