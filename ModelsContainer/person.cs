using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsContainer
{
  [Serializable]
  public  class person
    {
        public string Name { get; set; }
        public string email { get; set; }
        public List<string> alldata { get; set;}

        public person()
        {
            alldata = new List<string>();
            for (int n = 0; n < 1000; n++ )
            {
               
                alldata.Add("This is an Item and must be cosidered such");

            }

            Name = "Diego and others";
            email = "Pippo and Pluto";
        }



    }
}
