using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Code
{
    public class AnsModel
    {
        private int ansNumber;
        private string userAns;
        private string ansCorrect;
        private string rBSelected;
        public string UserAns
        {
            get { return userAns; }
            set { userAns = value; }
        }
        public string AnsCorrect
        {
            get { return ansCorrect; }
            set { ansCorrect = value; }
        }
        public string RBSelected
        {
            get { return rBSelected; }
            set { rBSelected = value; }
        }
        public int AnsNumber
        {
            get { return ansNumber; }
            set { ansNumber = value; }
        }
        public AnsModel(int ansNumber, string userAns, string ansCorrect, string rBSelected)
        {
            this.ansNumber = ansNumber;
            this.userAns = userAns;
            this.ansCorrect = ansCorrect;
            this.rBSelected = rBSelected;
        }
    }
}
