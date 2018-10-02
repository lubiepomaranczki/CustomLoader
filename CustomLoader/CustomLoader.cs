using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomLoader
{
    public class CustomLoader : Image
    {
        #region Fields

        private CancellationTokenSource cancellationToken;

        #endregion

        #region Binadables

        public static BindableProperty IsRunningProperty = BindableProperty.Create(
            propertyName: nameof(IsRunning),
            returnType: typeof(bool),
            declaringType: typeof(CustomLoader),
            defaultValue: false);

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static BindableProperty RotationLenghtProperty = BindableProperty.Create(
            propertyName: nameof(RotationLenght),
            returnType: typeof(int),
            declaringType: typeof(CustomLoader),
            defaultValue: 2500);

        public int RotationLenght
        {
            get { return (int)GetValue(RotationLenghtProperty); }
            set { SetValue(RotationLenghtProperty, value); }
        }

        #endregion

        #region Constructor(s)

        public CustomLoader()
        {
            Opacity = 0;
        }

        #endregion

        #region Overrides

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsRunningProperty.PropertyName)
            {
                if (IsRunning)
                {
                    this.FadeTo(1);
                    cancellationToken = new CancellationTokenSource();
                    RotateElement(this, cancellationToken.Token);
                }
                else
                {
                    cancellationToken?.Cancel();
                    this.FadeTo(0);
                }
            }
        }

        #endregion

        #region Methods

        private async Task RotateElement(VisualElement element, CancellationToken cancellation)
        {
            while (!cancellation.IsCancellationRequested)
            {
                await element.RotateTo(360, (uint)RotationLenght, Easing.CubicInOut);
                await element.RotateTo(0, 0); // reset to initial position
            }
        }

        #endregion
    }
}
