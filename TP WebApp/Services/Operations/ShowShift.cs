using Data.DataAccess;
using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Operations
{
    public class ShowShift
    {

        private ShiftsData repoShift = new ShiftsData();

        public List<ShiftModel> ShowAll()
        {

            var shiftList = new List<ShiftModel>();

            foreach (var x in repoShift.ReadAll())
            {
                shiftList.Add(new ConvertShift().ConvertModel(x));
            }

            return shiftList;
        }


        public ShiftModel ValidateShift(int id)
        {

            var shift = new ShiftModel();

            var shiftaux = repoShift.Read(id);

            if (shiftaux != null)
            {
                shift = new ConvertShift().ConvertModel(shiftaux);
            }

            return shift;
        }

        public Shift Select(string name)
        {
            var shift = new Shift();

            shift = new ConvertShift().Convert(ShowAll().FirstOrDefault(c => c.Name == name));
            
            return shift;
        }


}
}
