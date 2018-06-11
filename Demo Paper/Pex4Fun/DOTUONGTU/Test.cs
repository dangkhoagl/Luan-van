using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DOTUONGTU
{
    public enum TestResult{
        Passed,
        Failed,
        Unknown
    }

    public class Test
    {
        public string TestID { get; set; }
        public List<object> TestInputs { get; set; }
        public object TestOuput { get; set; }
        public TestResult Result { get; set; }
        public string TestCode { get; set; }
        public Test(List<object> testInputs, TestResult result, string testID, string testCode)
        {
            this.TestInputs = testInputs;
            this.Result = result;
            this.TestID = testID;
            this.TestCode = testCode;
        }
        public Test(List<object> testInputs, TestResult result)
        {
            this.TestInputs = testInputs;
            this.Result = result;
        }
        public Test(List<object> testInputs)
        {
            this.TestInputs = testInputs;
        }
        public Test()
        {
            this.TestInputs = new List<object>();
            this.Result = new TestResult();
        }
    }
}
