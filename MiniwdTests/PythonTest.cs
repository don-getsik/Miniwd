using System;
using System.Collections.Generic;
using System.Text;

namespace MiniwdTests
{
    [TestClass]
    class PythonTest
    {
        [TestMethod]
        public void SSHConnectionTest ()
        {
            string result;
            using (var client = new SshClient("40.113.78.173", "miniwd", "Miniwdna100%"))
            {
                client.Connect();
                result = client.RunCommand("echo 123").Result;
                client.Disconnect();
            }
            Assert.AreEqual("123\n", result);
        }

        [TestMethod]
        public void PythonTest()
        {
            string result;
            using (var client = new SshClient("40.113.78.173", "miniwd", "Miniwdna100%"))
            {
                client.Connect();
                result = client.RunCommand("python -c 'print(123)'").Result;
                client.Disconnect();
            }
            Assert.AreEqual("123\n", result);
        }

        [TestMethod]
        public void PythonTest()
        {
            string sklearn;
            string pandas;
            using (var client = new SshClient("40.113.78.173", "miniwd", "Miniwdna100%"))
            {
                client.Connect();
                sklearn = client.RunCommand(" /anaconda/envs/py35/bin/pip list | grep -c 'sklearn'").Result;
                pandas  = client.RunCommand(" /anaconda/envs/py35/bin/pip list | grep -c 'pandas'").Result;
                client.Disconnect();
            }
            Assert.AreEqual("1/n", sklearn);
            Assert.AreEqual("1/n", pandas);
        }
    }
}
