using GatesNBalls.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class TreeServiceTests
    {
        [TestMethod]
        public void WhichOneEmpty_ReturnsCorrectResults()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,L,R,L";

            var actual = service.WhichOneEmpty(4, sGates.Split(','));

            Assert.AreEqual(actual, 12);
        }

        [TestMethod]
        public void PredictEmpty_ReturnsCorrectResults()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,L,R,L";

            var actual = service.PredictEmpty(4, sGates.Split(','));

            Assert.AreEqual(actual, 12);
        }

        [TestMethod]
        public void FormTree_ReturnsCorrectResults()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,L,R,L";

            var tree = service.FormTree("4", sGates);

            Assert.AreEqual(tree.Depth, 4);
            Assert.AreEqual(tree.Gates.Length, 15);
            Assert.IsFalse(tree.Error);
            Assert.IsNull(tree.ErrorMessage);
        }

        [TestMethod]
        public void FormTree_ReturnsNotANumberError()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,L,R,L";

            var tree = service.FormTree("Four", sGates);

            Assert.IsTrue(tree.Error);
            Assert.AreEqual(tree.ErrorMessage, "The depth is not a number.");
        }

        [TestMethod]
        public void FormTree_ReturnsGatesNotMatchError()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,L";

            var tree = service.FormTree("4", sGates);

            Assert.IsTrue(tree.Error);
            Assert.AreEqual(tree.ErrorMessage, "Gates do not match depth.");
        }

        [TestMethod]
        public void FormTree_ReturnsIncorrectGateStatusError()
        {

            TreeService service = new TreeService();
            var sGates = "L,R,R,L,L,L,L,R,L,R,R,L,";

            var tree = service.FormTree("4", sGates);

            Assert.IsTrue(tree.Error);
            Assert.AreEqual(tree.ErrorMessage, "Gate status value/s not set correctly.");
        }

    }
}
