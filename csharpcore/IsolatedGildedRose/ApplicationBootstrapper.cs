using Ninject;

namespace IsolatedTests.GildedRose
{
    public class ApplicationBootstrapper
    {
        private readonly StandardKernel kernel;

        public ApplicationBootstrapper()
        {
            kernel = new StandardKernel();
        }
        
        public StandardKernel InitContainer()
        {
            kernel.Load(new GildedRoseModule());
            return kernel;
        }
    }
}