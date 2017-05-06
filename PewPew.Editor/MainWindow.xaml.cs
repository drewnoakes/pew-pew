using System;
using System.Windows;

namespace PewPew.Editor
{
    public partial class MainWindow
    {
        private readonly PewPewMixer _mixer = new PewPewMixer();
        private readonly PatchViewModel _viewModel = new PatchViewModel();

        public MainWindow()
        {
            DataContext = _viewModel;
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            _mixer.Dispose();
            base.OnClosed(e);
        }

        private async void OnPlay(object sender, RoutedEventArgs e)
        {
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        #region Presets

        private async void OnPickup(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Pickup());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnLaser(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Laser());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnExplosion(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Explosion());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnPowerUp(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.PowerUp());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnHurt(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Hurt());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnJump(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Jump());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        private async void OnBlip(object sender, RoutedEventArgs e)
        {
            _viewModel.FromPatch(PewPewGenerators.Blip());
            await _mixer.PlayAsync(_viewModel.ToPatch());
        }

        #endregion
    }
}
