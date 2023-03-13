using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Code
{
    public class AnsModel
    {
        private string userAns;
        private string ansCorrect;
        private string rBSelected;
        private int id;
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
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public AnsModel(int id,string userAns, string ansCorrect, string rBSelected)
        {
            this.id = id;
            this.userAns = userAns;
            this.ansCorrect = ansCorrect;
            this.rBSelected = rBSelected;
        }
    }
}
