using Zenject;

namespace Arkanoid
{
    public class BootstrapInstaller : MonoInstaller
    {
        public SwerveInput swerveInput;
        
        public override void InstallBindings()
        {
            BindSwerveInput();
        }

        private void BindSwerveInput()
        {
            Container
                .Bind<ISwerveInput>()
                .To<SwerveInput>()
                .FromComponentInNewPrefab(swerveInput)
                .AsSingle();
        }
    }
}