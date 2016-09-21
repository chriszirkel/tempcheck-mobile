using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TempCheckMobile.Model;
using TempCheckMobile.Services;
using Xamarin.Forms;

namespace TempCheckMobile.ViewModel
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        private Command startCommand;
        private Command stopCommand;

        public double Temperature { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsMonitoring { get; private set; }

        public Command StartCommand
        {
            get { return startCommand ?? (startCommand = new Command(() => StartMonitoring())); }
        }

        public Command StopCommand
        {
            get { return stopCommand ?? (stopCommand = new Command(() => StopMonitoring())); }
        }

        public MainViewModel()
        {

        }

        public async Task StartMonitoring()
        {
            IsMonitoring = true;

            await UpdateTemperature();

            Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Task.Factory.StartNew(async () =>
                {
                    await UpdateTemperature();
                });

                return IsMonitoring;
            });
        }

        public void StopMonitoring()
        {
            IsMonitoring = false;
        }

        private async Task UpdateTemperature()
        {
            var temperature = await AmazonWebService.Instance.LoadAsync<Temperature>(App.DeviceId);

            Device.BeginInvokeOnMainThread(() =>
            {
                Temperature = temperature.Value;
                Timestamp = temperature.Timestamp;
            });
        }
    }
}
