using System.Windows.Forms;
using NUnit.Framework;

namespace LightroomImporter.Test
{
    [TestFixture]
    public abstract class BaseTest
    {
        public void AskManualTestToBeRunQuestion(string message)
        {
            if (MessageBox.Show(message, "Start Test?", MessageBoxButtons.YesNo) == DialogResult.Yes) return;
            Assert.Fail("Test Declined.");
        }
    }
}
