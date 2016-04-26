using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Week15ExamPrep
{
    [DataContract(Namespace = "http://www.cnn.com/rox", Name = "Alien", IsReference = true)]
    class Human
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Occupation { get; set; }

        [DataMember(Order = 1)]
        public MaritalStatus MaritalStatus { get; set; }

        [DataMember(Order = 0)]
        public decimal Weight { get; set; }

        [DataMember(Order = 1)]
        public string HairColor { get; set; }

        [DataMember(Order = 3)]
        public Human Sibling { get; set; }
    }
}
